//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp8
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int Order_id { get; set; }
        public string Customer_id { get; set; }
        public int Product_id { get; set; }
        public string Employee_id { get; set; }
        public int Product_quntity { get; set; }
        public Nullable<int> Discount { get; set; }
        public int Order_price { get; set; }
        public string Delivery_addres { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Products Products { get; set; }
    }
}
