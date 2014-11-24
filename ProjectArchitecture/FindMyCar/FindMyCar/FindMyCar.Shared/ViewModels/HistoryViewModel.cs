using FindMyCar.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCar.ViewModels
{
    public class HistoryViewModel
    {
        public const string dbName = "CarLeftsDataBase3.db";

        public HistoryViewModel()
        {

            this.LoadPhones();
        }

        private ObservableCollection<CarLeftDbViewModel> carLeftsInfoItems;

        public IEnumerable<CarLeftDbViewModel> CarLeftsInfoItems
        {
            get
            {
                if (this.carLeftsInfoItems == null)
                {
                    this.CarLeftsInfoItems = new ObservableCollection<CarLeftDbViewModel>();
                }
                return this.carLeftsInfoItems;
            }
            set
            {
                if (this.carLeftsInfoItems == null)
                {
                    this.carLeftsInfoItems = new ObservableCollection<CarLeftDbViewModel>();
                }
                this.carLeftsInfoItems.Clear();
                foreach (var item in value)
                {
                    this.carLeftsInfoItems.Add(item);
                }
            }

        }


        public async void LoadPhones()
        {
            List<CarLeftModel> items = await getFromDatabase();

            List<CarLeftDbViewModel> convertedItems = new List<CarLeftDbViewModel>();

            foreach (var item in items)
            {
                convertedItems.Add(new CarLeftDbViewModel() { Username = item.Username, Car = item.CarNumber });
            }

            CarLeftsInfoItems = convertedItems;
        }


        public async Task<List<CarLeftModel>> getFromDatabase()
        {
            // Get Articles
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            var query = conn.Table<CarLeftModel>();
            List<CarLeftModel> lefts = await query.ToListAsync();
            return lefts;
        }
    }
}
