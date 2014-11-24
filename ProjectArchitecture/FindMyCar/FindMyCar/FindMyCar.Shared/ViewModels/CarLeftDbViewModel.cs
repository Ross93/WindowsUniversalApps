using FindMyCar.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FindMyCar.ViewModels
{
    public class CarLeftDbViewModel
    {
        public static Expression<Func<CarLeftModel, CarLeftDbViewModel>> FromModel
        {
            get
            {
                return model =>
                    new CarLeftDbViewModel()
                    {
                        Username = model.Username,
                        Car = model.CarNumber
                    };
            }
        }

        public string Username { get; set; }
        public string Car { get; set; }
    }
}
