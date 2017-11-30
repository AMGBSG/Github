using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GonzalesP2.Models
{
    public class InvestmentCalc
    {
        #region Notes
        //Notes for DataAnnotations
        //[Required(ErrorMessage = "*")]
        //[DisplayFormat(DataFormatString = "{0:d}")]
        //[DataType(DataType.Date)]
        #endregion

        #region Fields

        private int compPerYr;
        private int years;
        private double interest;
        private double principal;
        #endregion

        #region Properties

        //set range, display name, and make required 
        [Required(ErrorMessage = "Compounds per year is required")]
        [Display(Name = "Compounds per year")]
        [Range(1, 24)]
        public int CompPerYr
        {
            get
            {
                return compPerYr;
            }
            set
            {
                compPerYr = value;
                Calc();
            }
        }

        //set range, and make required 
        [Required(ErrorMessage = "Years is required")]
        [Range(1, 30)]
        public int Years
        {
            get
            {
                return years;
            }
            set
            {
                years = value;
                Calc();
            }
        }

        //set range, display format, and make required 
        [Required(ErrorMessage = "Interest is required")]
        [Range(0.01, 100)]
        [DisplayFormat(DataFormatString = @"{0:#.#\%}")] 
        public double Interest
        {
            get
            {
                return interest;
            }
            set
            {
                interest = value;
                Calc();
            }
        }

        //set range, display format, and make required 
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, Double.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double Principal
        {
            get
            {
                return principal;
            }
            set
            {
                principal = value;
                Calc();
            }
        }
        
        //set range, display name, and format 
        [Range(0.01, Double.MaxValue)]
        [Display(Name = "Future Value")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)] // [Display(Name = "Country")]
        //only has a getter
        public double FutureValue { get; set; }
   
        #endregion

        #region Methods
        //chaining the default ocnstructor with the values numTimes = 0, years = 00, interest = 0, principle = 0
        public InvestmentCalc():this(0,0,0,0)
        {
          
        }

        //set the class variables in the overloaded constructor
        public InvestmentCalc(int compPerYr, int years, double interest, double principal)
        {
           
                this.compPerYr = compPerYr;
                this.years = years;
                this.interest = interest;
                this.principal = principal;
                Calc();
            
        }
        private void Calc()
        {
            //A=P(1+r/n)^nt
            //A = amount
            //P = principal(principal)
            //r = IntrestRate(decimal)(interest
            //n = Number of times interest is compounded per year (compPerYr)
            //t = Time (years)

            //long way *************************
            //double num1 = (1 + ((interest/100) / compPerYr));
            //double num2 = (compPerYr * years);
            //double pow = Math.Pow(num1, num2);
            //amount = (principal * pow);

            //short way*******************
            FutureValue = (principal * (Math.Pow((1 + ((interest / 100) / compPerYr)), (compPerYr * years))));
        }

        #endregion

    }
}