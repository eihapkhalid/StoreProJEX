using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBl;
using StoreBl.Bl;
using StoreBl.Models;
using static System.Collections.Specialized.BitVector32;

namespace StoreProjectEx
{
    public class UiHelper
    {
        #region MainOptionsFunction
        public static void MainOptions()
        {
            Console.WriteLine("*** wlc to our store :\n");
            Console.WriteLine("To mange Store Press   1 ");
            Console.WriteLine("To mange Items Press   2 ");
            Console.WriteLine("To mange Orders Press  3 ");
            Console.WriteLine("To mange Report Press  4 ");
            Console.WriteLine("To close the app press 0 ");
        } 
        #endregion

        #region StoreOptionsFunction
        public static void StoreOptions()
        {
            string sStoreOptions = String.Empty;
            while (sStoreOptions != "0")
            {

                Console.WriteLine("*** wlc to mange store data :\n");
                Console.WriteLine("To add Store Press   1 ");
                Console.WriteLine("To get all store Press   2 ");
                Console.WriteLine("To delete Store Press   3 ");
                Console.WriteLine("To go back press 0 ");
                sStoreOptions = Console.ReadLine();

                ClsStores oClsStores = new ClsStores();
                switch (sStoreOptions)
                {
                    case "0":
                        Console.Clear();
                        sStoreOptions = "0";
                        break;

                    case "1":
                        Console.Clear();
                        StoreModel oStoreModel = new StoreModel();
                        /* Console.WriteLine("plz enter store id");

                         int IWillTry;
                         bool ICanConvert = int.TryParse(Console.ReadLine(), out IWillTry);

                         if (ICanConvert) 
                         {
                             oStoreModel.StoreId = IWillTry;
                         }
                         else
                         {
                             Console.WriteLine("plz enter valid number");
                             break;
                         }*/

                        Console.WriteLine("plz enter store NAME");
                        oStoreModel.StoreName = Console.ReadLine();

                        oClsStores.Add(oStoreModel);
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();
                        ShowALLstores(oClsStores.GetAll());
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("plz enter store id");

                        int IWillTry;
                        bool bICanConvert = int.TryParse(Console.ReadLine(), out IWillTry);

                        if (bICanConvert)
                        {
                            bool bisDeleted = oClsStores.Delete(IWillTry);
                            if (!bisDeleted)
                            {
                                Console.WriteLine("Id Not Found !!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("plz enter valid Id");
                            break;
                        }
                        break;
                }
            }

        } 
        #endregion

        #region ItemOptionsFunction
        public static void ItemOptions()
        {
            string sItemOptions = String.Empty;
            while (sItemOptions != "0")
            {

                Console.WriteLine("*** wlc to mange item data :\n");
                Console.WriteLine("To add item Press   1 ");
                Console.WriteLine("To get all item Press   2 ");
                Console.WriteLine("To delete item Press   3 ");
                Console.WriteLine("To go back press 0 ");
                sItemOptions = Console.ReadLine();

                ClsItems oClsItems = new ClsItems();
                switch (sItemOptions)
                {
                    case "0":
                        Console.Clear();
                        sItemOptions = "0";
                        break;

                    case "1":
                        Console.Clear();
                        ItemModel oItemModel = new ItemModel();
                        #region Hached
                        /* Console.WriteLine("plz enter store id");

                 int IWillTry;
                 bool ICanConvert = int.TryParse(Console.ReadLine(), out IWillTry);

                 if (ICanConvert) 
                 {
                     oStoreModel.StoreId = IWillTry;
                 }
                 else
                 {
                     Console.WriteLine("plz enter valid number");
                     break;
                 }*/
                        #endregion

                        Console.WriteLine("plz enter item NAME");
                        oItemModel.ItemName = Console.ReadLine();

                        Console.WriteLine("plz enter item price");
                        Decimal dItmePrice = 0;
                        bool bCanConverted = decimal.TryParse(Console.ReadLine(), out dItmePrice);
                        if (bCanConverted)
                        {
                            oItemModel.ItemPrice = dItmePrice;
                        }
                        else
                        {
                            Console.WriteLine("plz enter valid price");
                        }

                        oClsItems.Add(oItemModel);
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();
                        ShowALLItems(oClsItems.GetAll());
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("plz enter item id");

                        int IWillTry;
                        bool bICanConvert = int.TryParse(Console.ReadLine(), out IWillTry);

                        if (bICanConvert)
                        {
                            bool bisDeleted = oClsItems.Delete(IWillTry);
                            if (!bisDeleted)
                            {
                                Console.WriteLine("Id Not Found !!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("plz enter valid Id");
                            break;
                        }
                        break;
                }
            }

        }
        #endregion

        #region OrderOptionsFunction
        public static void OrderOptions()
        {
            string sOrderOptions = String.Empty;
            while (sOrderOptions != "0")
            {

                Console.WriteLine("*** wlc to mange Order data :\n");
                Console.WriteLine("To add Order Press   1 ");
                Console.WriteLine("To get all Order Press   2 ");
                Console.WriteLine("To delete Order Press   3 ");
                Console.WriteLine("To go back press 0 ");
                sOrderOptions = Console.ReadLine();

                ClsOrders oClsOrders = new ClsOrders();
                int nOrderId = 0;// use for trypass
                switch (sOrderOptions)
                {
                    case "0":
                        Console.Clear();
                        sOrderOptions = "0";
                        break;

                    case "1":
                        Console.Clear();
                        OrderModel oOrderModel = new OrderModel();


                        Console.WriteLine("plz enter OrderItem.ItemId  ");
                        bool bCanConvert = int.TryParse(Console.ReadLine(), out nOrderId);
                        if (bCanConvert)
                        {
                            oOrderModel.OrderItem.ItemId = nOrderId;

                        }
                        else
                        {
                            Console.WriteLine("enter valid id");
                        }

                        Console.WriteLine("plz enter OrderStore.StoreId   ");
                        bCanConvert = int.TryParse(Console.ReadLine(), out nOrderId);
                        if (bCanConvert)
                        {
                            oOrderModel.OrderStore.StoreId = nOrderId;

                        }
                        else
                        {
                            Console.WriteLine("enter valid id");
                        }

                        oClsOrders.Add(oOrderModel);
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();
                        ShowALLOrders(oClsOrders.GetAll());
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("plz enter store id");

                        int IWillTry;
                        bool bICanConvert = int.TryParse(Console.ReadLine(), out IWillTry);

                        if (bICanConvert)
                        {
                            bool bisDeleted = oClsOrders.Delete(IWillTry);
                            if (!bisDeleted)
                            {
                                Console.WriteLine("Id Not Found !!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("plz enter valid Id");
                            break;
                        }
                        break;
                }
            }

        }
        #endregion

        #region ShowALLstoresFunction
        public static void ShowALLstores(List<StoreModel> lstStores)
        {
            Console.WriteLine("*******************\n\n");
            foreach (var store in lstStores)
            {
                Console.WriteLine(string.Format("store id {0} store name {1}", store.StoreId, store.StoreName));
            }
            Console.WriteLine("\n\n*******************\n\n");
        }
        #endregion

        #region ShowALLItemsFunction
        public static void ShowALLItems(List<ItemModel> lstItems)
        {
            Console.WriteLine("*******************\n\n");
            foreach (var item in lstItems)
            {
                Console.WriteLine(string.Format("(item id {0})  (item name {1})   (item price {2})", item.ItemId, item.ItemName, item.ItemPrice));
            }
            Console.WriteLine("\n\n*******************\n\n");
        }
        #endregion

        #region ShowALLIOrderFunction
        public static void ShowALLOrders(List<OrderModel> lstOrderss)
        {
            Console.WriteLine("*******************\n\n");
            foreach (var order in lstOrderss)
            {
                Console.WriteLine(string.Format("(order id {0})  (order data {1})   (order item {2})  (order store {3})", order.OrderId, order.OrderDateTime, order.OrderItem.ItemId, order.OrderStore.StoreId));
            }
            Console.WriteLine("\n\n*******************\n\n");
        }
        #endregion
    }
}
