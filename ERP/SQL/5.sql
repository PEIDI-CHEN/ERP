USE [tsJXC]
GO
/****** Object:  StoredProcedure [dbo].[sp_GiffWage]    Script Date: 06/27/2019 08:16:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER     Procedure [dbo].[sp_GiffWage](@strMonth varchar(20))
as 

declare @strColumn     varchar(2000),
        @strHide       varchar(20),
        @strSum        varchar(2000),
        @strWageColumn varchar(2000),
        @strField      varchar(6000),
        @strSQL        varchar(8000),
        @intFlag       int

set @strField= ''
set @strSQL= ''
set @strSum = ''
set @strWageColumn = ''

declare cursor_Wage cursor for
/*select F_HideItem,F_Flag,(case isnull(F_Formula,'') when '' then F_HideItem else F_Formula end)*/
select F_HideItem,F_Flag,(case isnull(F_Formula,'') when '' then '0' else F_Formula end)
from t_WageItem

/*select F_HideItem,F_Flag from t_WageItem  where F_Formula<>null*/
  

open  cursor_Wage

fetch next from cursor_Wage into @strHide,@intFlag,@strColumn

while @@FETCH_STATUS = 0
begin
  
  set @strWageColumn = @strWageColumn + @strHide+',tp.'

  set @strField = @strField + @strHide+','
  if @intFlag = 0
     set @strSum = @strSum + 'isnull('+@strColumn + ',0)*(-1) +' 
  else
     set @strSum = @strSum + 'isnull(' + @strColumn + ',0)+' 
  fetch next from cursor_Wage into @strHide,@intFlag,@strColumn
end

close  cursor_Wage
deallocate cursor_Wage

set @strWageColumn = left(@strWageColumn,(len(@strWageColumn) - 3))

set @strField = left(@strField,len(@strField) - 1)
set @strSum = left(@strSum,len(@strSum) - 1)
set @strSum = '(isnull(tp.F_BaseWage,0) + isnull(F_CalWage,0)+'+@strSum+') as F_TotalSum'

set @strSQL = 'select F_Month,b.F_Type,F_EmpID,b.F_Name,tp.F_BaseWage,F_CalWage,tp.'+ @strWageColumn + @strSum +' from ('

set @strSQL = @strSQL + 'select F_Month,F_EmpID,F_BaseWage,F_CalWage,'+@strField
set @strSQL = @strSQL + ' from t_GenWage ) as tp,t_Emp b where tp.F_EmpID = b.F_ID'
set @strSQL = @strSQL + ' and tp.F_Month = '+@strMonth


execute(@strSQL)