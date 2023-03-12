using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBl.Models
{
    public class OrderModel
    {
        //we use this constrctor to put default value (not null value)
        public OrderModel()
        {
            OrderDateTime = DateTime.Now;
            OrderItem = new ItemModel();
            OrderStore = new StoreModel();
        }
        public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public ItemModel OrderItem { get; set; }
        public StoreModel OrderStore { get; set; }

    }
}
