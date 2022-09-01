using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project1._1
{
   public interface CRUD
    {
        
        void AddRecord(Inventory inventory);
        void DeleteRecord(Inventory inventory);

        ICollection<Inventory> GetAllRecords();
        Inventory FindItem(int serial);
        void UpdateRecord(int serial, Inventory inventory);

        void SellItem(int serial, Inventory inventory, int Quantity);
    }

   public class InvRepository : CRUD
    {
        PCAD7GarageEntities entities;

        public InvRepository()
        {
            entities = new PCAD7GarageEntities();
        }
        
        
        public void AddRecord(Inventory inventory)
        {
            entities.Inventories.Add(inventory);// add the item object in list
            entities.SaveChanges();
        }

        public void DeleteRecord(Inventory inventory)
        {
            entities.Inventories.Remove(inventory);
            entities.SaveChanges();

        }

        public Inventory FindItem(int serial)
        {
            return entities.Inventories.Find(serial);
        }

        public ICollection<Inventory> GetAllRecords()
        {
            return entities.Inventories.ToList();
        }
        public void UpdateRecord(int serial, Inventory inventory)
        {
            var invtoupdate = entities.Inventories.Find(serial);//ref of the emp
            invtoupdate.Serial = inventory.Serial;
            invtoupdate.Item_Name = inventory.Item_Name;
            invtoupdate.Item_Quantity = inventory.Item_Quantity;
            invtoupdate.Quantity_Sold = inventory.Quantity_Sold;
            invtoupdate.Unit_Price = inventory.Unit_Price;
            entities.SaveChanges();
        }
        public void SellItem(int serial, Inventory inventory,int Quantity)
        {
            var invtoupdate = entities.Inventories.Find(serial);
            invtoupdate.Item_Quantity = inventory.Item_Quantity- Quantity;
            invtoupdate.Quantity_Sold = inventory.Quantity_Sold+Quantity;
            entities.SaveChanges();
        }   }
}


       
      

        
 
