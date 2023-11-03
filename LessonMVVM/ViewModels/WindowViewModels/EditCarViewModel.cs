using LessonMVVM.Commands;
using LessonMVVM.Models;
using LessonMVVM.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LessonMVVM.ViewModels.WindowViewModels
{
    public class EditCarViewModel : NotificationService
    {
        private Car? editCar;
        private Car? car1;
        
        public Car? EditCar { get => editCar; set { editCar = value; OnPropertyChanged(); } }
        public Car? car { get => car1; set { car1 = value; OnPropertyChanged(); } }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CanleCommand { get; set; }

        public EditCarViewModel(Car? car)
        {
            this.car = car;
            this.EditCar = new Car(car?.Make, car?.Model, car?.Date);

            

            SaveCommand = new RelayCommand(SaveCar, CanSaveCar);
            CanleCommand = new RelayCommand(CanleCar, CanCanleCar);
            
        }

        public bool CanSaveCar(object? obj)
        {

            if (EditCar?.Make != null && EditCar?.Model != null && EditCar?.Date != null) { return true; }

            return false;
            
        }

        public void SaveCar(object? obj)
        {
            car.Make = EditCar?.Make;
            car.Model = EditCar?.Model;
            car.Date = EditCar?.Date;

            Window v = obj as Window;
            v.Close();
        }

        public bool CanCanleCar(object? obj)
        {

            

            return true;

        }

        public void CanleCar(object? obj)
        {

            Window v = obj as Window;
            v.Close();
        }



    }
}
