
/****** Object:  StoredProcedure [dbo].[sp_AutoGenStockOrder]    Script Date: 01/12/2011 16:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_AutoGenStockOrder](@Bill varchar(30))
as

declare @sSupplier varchar(30),
        @BillID varchar(30),
        @i int 

select @i = 0
declare Cur_Bill cursor for
select b.F_SupplierID from t_ApplyStock a,t_ApplyStockDetail b
where a.F_BillID = b.F_BillID
and a.F_BillID = @Bill
group by b.F_SupplierID

open  Cur_Bill
fetch next from Cur_Bill into @sSupplier
                                    
while @@FETCH_STATUS = 0
begin
 select @i = @i + 1
 select @BillID = 'AO' + right('0000'+cast((cast(isnull(MAX(RIGHT(F_BillID,5)),'0') as int) + 1) as varchar(5)),5) from t_StockOrder
 where left(F_BillID,2) = 'AO'
 
 insert into t_StockOrder(F_BillID,F_Date,F_SupplierID,F_StockTime,F_BillMan,F_CheckMan,F_Check,F_CheckDate,F_Finish,F_CutOff,F_Invalid,F_Remark)
 select @BillID,GETDATE(),@sSupplier,GETDATE(),'','',0,'1900-1-1',0,0,0,'由申购单['+@Bill+']自动生成'
 
 insert into t_StockOrderDetail(F_BillID,Aid,F_ItemID,F_Unit,F_Qty,F_Price,F_LinkBill,PAid)
 select @BillID,b.Aid,b.F_ItemID,b.F_Unit,b.F_Qty,b.F_Price,a.F_BillID,b.Aid from t_ApplyStock a,  t_ApplyStockDetail b
 where a.F_BillID = b.F_BillID
 and a.F_BillID = @Bill
 and b.F_SupplierID = @sSupplier
 
 fetch next from Cur_Bill into @sSupplier
end

close  Cur_Bill
deallocate Cur_Bill
