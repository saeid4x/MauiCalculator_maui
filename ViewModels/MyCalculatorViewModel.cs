using Dangl.Calculator;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorDemo2.ViewModels
{
    [AddINotifyPropertyChangedInterface]
     public class MyCalculatorViewModel
    {

        public string  Formula { get; set; }
        public string Result { get; set; } = "0";

        public ICommand OperationCommand =>
            new Command((number) =>
            {
                Formula = Formula + number;
            });


        public ICommand CalculationCommand =>
            new Command(() =>
            {
                var calculation = Calculator.Calculate(Formula);
                Result = calculation.Result.ToString();
            });


        public ICommand ResetCommand =>
            new Command(() =>
            {
                Formula = "";
                Result = "0";
            });

        public ICommand BackspaceCommand =>
          new Command(() =>
          {
              Formula = Formula.Substring(0,Formula.Length - 1);
          });



    }
}
