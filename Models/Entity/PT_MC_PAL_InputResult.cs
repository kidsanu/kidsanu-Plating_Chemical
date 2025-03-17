using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{
    public class PT_MC_PAL_InputResult
    {
        public PT_MC_PAL_InputResult()
        {
            this.PT_MC_PAL_InputResultList = new List<PT_MC_PAL_InputResult>();
        }
        public List<PT_MC_PAL_InputResult> PT_MC_PAL_InputResultList { get; set; }
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


        //For Pal
        public int[] intNoPal = new int[7];
        public string[] strPartNoPal = new string[7];
        public string[] strMachineCodePal = new string[7];
        public string[] strchemicalTankPal = new string[7];
        public string[] strchemicalTank_idPal = new string[7];
        public string[] stranalysisItemPal = new string[7];
        public double[] douTritratePal = new double[7];
        public string[] strWorkPal = new string[7];
        public string[] strRepPal = new string[7];
        public double[] douActualPal = new double[7];
        public string[] strRemarkPal = new string[7];



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



        ////Model for Graph Alchelate Protek 1

        public string[] strDailyX = new string[] { };
        public double[] douL = new double[] { };
        public double[] douM = new double[] { };
        public double[] douH = new double[] { };


        //Model for Graph Copper Protek 1
        public string[] strDailyX_Copper = new string[] { };
        public double[] douL_Copper = new double[] { };
        public double[] douM_Copper = new double[] { };
        public double[] douH_Copper = new double[] { };

        //Model for Graph Sulfuric Protek 1
        public string[] strDailyX_Sulfuric = new string[] { };
        public double[] douL_Sulfuric = new double[] { };
        public double[] douM_Sulfuric = new double[] { };
        public double[] douH_Sulfuric = new double[] { };

        //Model for Graph Chloride Protek 1
        public string[] strDailyX_Chloride = new string[] { };
        public double[] douL_Chloride = new double[] { };
        public double[] douM_Chloride = new double[] { };
        public double[] douH_Chloride = new double[] { };

        //Model for Graph HS200PARTAa is 01-15 Protek 1
        public string[] strDailyX_HS200PARTA1 = new string[] { };
        public double[] douL_HS200PARTA1 = new double[] { };
        public double[] douM_HS200PARTA1 = new double[] { };
        public double[] douH_HS200PARTA1 = new double[] { };

        //Model for Graph HS200PARTAa is 16-30,31 Protek 1
        //public string[] strDailyX_HS200PARTA2 = new string[] { };
        //public double[] douL_HS200PARTA2 = new double[] { };
        //public double[] douM_HS200PARTA2 = new double[] { };
        //public double[] douH_HS200PARTA2 = new double[] { };


        //Model for Graph HS200PARTB Protek 1
        public string[] strDailyX_HS200PARTB = new string[] { };
        public double[] douL_HS200PARTB = new double[] { };
        public double[] douM_HS200PARTB = new double[] { };
        public double[] douH_HS200PARTB = new double[] { };



        //Model for Graph EVF Brightener  
        public string[] strDailyX_EVFBRIGH = new string[] { };
        public double[] douL_EVFBRIGH = new double[] { };
        public double[] douM_EVFBRIGH = new double[] { };
        public double[] douH_EVFBRIGH = new double[] { };

        //Model for Graph EVF Leveller
        public string[] strDailyX_LEVELLER = new string[] { };
        public double[] douL_LEVELLER = new double[] { };
        public double[] douM_LEVELLER = new double[] { };
        public double[] douH_LEVELLER = new double[] { };

        //Model for Graph EVF C-2  
        public string[] strDailyX_EVF_C2 = new string[] { };
        public double[] douL_EVF_C2 = new double[] { };
        public double[] douM_EVF_C2 = new double[] { };
        public double[] douH_EVF_C2 = new double[] { };


        //Model for Graph ST-901AM
        public string[] strDailyX_ST_901AM = new string[] { };
        public double[] douL_ST_901AM = new double[] { };
        public double[] douM_ST_901AM = new double[] { };
        public double[] douH_ST_901AM = new double[] { };

        //Model for Graph ST-901BM
        public string[] strDailyX_ST_901BM = new string[] { };
        public double[] douL_ST_901BM = new double[] { };
        public double[] douM_ST_901BM = new double[] { };
        public double[] douH_ST_901BM = new double[] { };

        //Model for Graph Melplate
        public string[] strDailyX_Melplate = new string[] { };
        public double[] douL_Melplate = new double[] { };
        public double[] douM_Melplate = new double[] { };
        public double[] douH_Melplate = new double[] { };


    }
}