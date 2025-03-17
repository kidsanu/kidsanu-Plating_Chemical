using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{
    public class PT_MC_DESMEAR_InputResult
    {
        public PT_MC_DESMEAR_InputResult()
        {
            this.PT_MC_DESMEAR_InputResultList = new List<PT_MC_DESMEAR_InputResult>();
        }
        public List<PT_MC_DESMEAR_InputResult> PT_MC_DESMEAR_InputResultList { get; set; }
        [Display(Name = "Transaction ID :")]
        public int TRANSACTION_ID { get; set; }
        [Display(Name = "Machine Code :")]
        public string MACHINE_CODE { get; set; }
        [Display(Name = "Machine Name :")]
        public string MACHINE_NAME { get; set; }
        [Display(Name = "Part No. :")]
        public string PART_NO { get; set; }
        public string CHECK_POINT { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date :")]
        public DateTime DATED { get; set; }

        [Display(Name = "Time :")]
        public string TIMED { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date :")]
        public DateTime DATED_APPLIED { get; set; }
        [Display(Name = "Employee Code :")]
        public string EMPLOYEE_CODE { get; set; }
        [Display(Name = "Employee Name :")]
        public string EMPLOYEE_NAME { get; set; }

        [Display(Name = "Tritrate :")]
        public double? TRITRATE { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE2 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE3 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE4 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE5 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE6 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE7 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE8 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE9 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE10 { get; set; }
        //[UIHint("BlankIfZero")]
        public double? TRITRATE11 { get; set; }

        public double? TRITRATE12 { get; set; }






        public double RES { get; set; }

        [Display(Name = "Actual Supply :")]
        public double? ACTUAL_SUPPLY { get; set; }

        public double? ACTUAL_SUPPLY2 { get; set; }
        public double? ACTUAL_SUPPLY3 { get; set; }
        public double? ACTUAL_SUPPLY4 { get; set; }
        public double? ACTUAL_SUPPLY5 { get; set; }
        public double? ACTUAL_SUPPLY6 { get; set; }
        public double? ACTUAL_SUPPLY7 { get; set; }
        public double? ACTUAL_SUPPLY8 { get; set; }
        public double? ACTUAL_SUPPLY9 { get; set; }
        public double? ACTUAL_SUPPLY10 { get; set; }
        public double? ACTUAL_SUPPLY11 { get; set; }
        public double? ACTUAL_SUPPLY12 { get; set; }




        ////For ALMAX
        //public int[] intNoAlmex = new int[11];
        //public string[] strPartNoAlmex = new string[11];
        //public string[] strMachineCodeAlmex = new string[11];
        //public string[] strchemicalTankAlmex = new string[11];
        //public string[] strchemicalTank_idAlmex = new string[11];
        //public string[] stranalysisItemAlmex = new string[11];
        //public double[] douTritrateAlmex = new double[11];
        //public string[] strWorkAlmex = new string[11];
        //public string[] strRepAlmex = new string[11];
        //public double[] douActualAlmex = new double[11];
        //public string[] strRemarkAlmex = new string[11];


        //For Desmear
        public int[] intNoDesmear = new int[7];
        public string[] strPartNoDesmear = new string[7];
        public string[] strMachineCodeDesmear = new string[7];
        public string[] strchemicalTankDesmear = new string[7];
        public string[] strchemicalTank_idDesmear = new string[7];
        public string[] stranalysisItemDesmear = new string[7];
        public double[] douTritrateDesmear = new double[7];
        public string[] strWorkDesmear = new string[7];
        public string[] strRepDesmear = new string[7];
        public double[] douActualDesmear = new double[7];
        public string[] strRemarkDesmear = new string[7];



        [Display(Name = "Shift :")]
        public string SHIFT { get; set; }
        [Display(Name = "Work :")]
        public string WORKING { get; set; }
        public string WORKING9 { get; set; }
        public string WORKING10 { get; set; }

        [Display(Name = "Rep.Cal :")]
        public string REP_CALC { get; set; }
        public string REP_CALC9 { get; set; }
        public string REP_CALC10 { get; set; }
        public string REP_CALC11 { get; set; }
        public string REP_CALC12 { get; set; }

        public string REMARK { get; set; }
        [Display(Name = "Chemical Tank ID :")]
        public string CHEMICAL_TANK_ID { get; set; }
        [Display(Name = "Chemical Tank Name :")]
        public string CHEMICAL_TANK_NAME { get; set; }
        [Display(Name = "Chemical Name :")]
        public string CHEMICAL_NAME { get; set; }





        public string strPersonName;


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Monthly :")]
        public string START_DATED { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        [Display(Name = "End Date :")]
        public DateTime END_DATED { get; set; }



        //Model for Graph Hole Prep 4125 (Bath Strength)Desmear

        public string[] strDailyX_4125Bath = new string[] { };
        public double[] douL_4125Bath = new double[] { };
        public double[] douM_4125Bath = new double[] { };
        public double[] douH_4125Bath = new double[] { };

        //Model for Graph Hole Prep 4125 Alkaline Nurmality Desmear
        public string[] strDailyX_4125Alkaline = new string[] { };
        public double[] douL_4125Alkaline = new double[] { };
        public double[] douM_4125Alkaline = new double[] { };
        public double[] douH_4125Alkaline = new double[] { };

        //Model for Graph Permanganate Desmear
        public string[] strDailyX_Permanganate = new string[] { };
        public double[] douL_Permanganate = new double[] { };
        public double[] douM_Permanganate = new double[] { };
        public double[] douH_Permanganate = new double[] { };

        //Model for Graph Manganate Desmear
        public string[] strDailyX_Manganate = new string[] { };
        public double[] douL_Manganate = new double[] { };
        public double[] douM_Manganate = new double[] { };
        public double[] douH_Manganate = new double[] { };

        //Model for Graph Alkaline Normality Desmear
        public string[] strDailyX_Alkaline = new string[] { };
        public double[] douL_Alkaline = new double[] { };
        public double[] douM_Alkaline = new double[] { };
        public double[] douH_Alkaline = new double[] { };

        //Model for Graph Neutralizer Desmear
        public string[] strDailyX_Neutralizer = new string[] { };
        public double[] douL_Neutralizer = new double[] { };
        public double[] douM_Neutralizer = new double[] { };
        public double[] douH_Neutralizer = new double[] { };

        //Model for Graph Neutralizer Bath conc Desmear
        public string[] strDailyX_NeutralizerBath = new string[] { };
        public double[] douL_NeutralizerBath = new double[] { };
        public double[] douM_NeutralizerBath = new double[] { };
        public double[] douH_NeutralizerBath = new double[] { };

        //Model for Graph Neutralizer 216-5M Desmear
        public string[] strDailyX_Neutralizer2165M = new string[] { };
        public double[] douL_Neutralizer2165M = new double[] { };
        public double[] douM_Neutralizer2165M = new double[] { };
        public double[] douH_Neutralizer2165M = new double[] { };

    }
}