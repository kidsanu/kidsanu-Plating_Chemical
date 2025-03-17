using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{

    public class PT_MC_InputResult
    {
        public PT_MC_InputResult()
        {
            this.PT_MC_InputList = new List<PT_MC_InputResult>();
        }
        public List<PT_MC_InputResult> PT_MC_InputList { get; set; }
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

        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        //[Display(Name = "Date :")]
        //public Nullable<DateTime> DATED { get; set; }

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
        // [UIHint("BlankIfZero")]
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
        public string CHEMICAL_TANK_NAME {get;set;}
        [Display(Name = "Chemical Name :")]
        public string CHEMICAL_NAME { get; set; }





        public string strPersonName;

        //For Protek1
        public int[] intNo = new int[11];
        public string[] strPartNo = new string[11];
        public string[] strMachineCode = new string[11];
        public string[] strchemicalTank = new string[11];
        public string[] strchemicalTank_id = new string[11];
        public string[] stranalysisItem = new string[11];
        public double[] douTritrate = new double[11];
        public string[] strWork = new string[11];
        public string[] strRep = new string[11];
        public double[] douActual = new double[11];
        public string[] strRemark = new string[11];

        //For Protek2
        public int[] intNoPT2 = new int[12];
        public string[] strPartNoPT2 = new string[12];
        public string[] strMachineCodePT2 = new string[12];
        public string[] strchemicalTankPT2 = new string[12];
        public string[] strchemicalTank_idPT2 = new string[12];
        public string[] stranalysisItemPT2 = new string[12];
        public double[] douTritratePT2 = new double[12];
        public string[] strWorkPT2 = new string[12];
        public string[] strRepPT2 = new string[12];
        public double[] douActualPT2 = new double[12];
        public string[] strRemarkPT2 = new string[12];

        //For Protek3
        public int[] intNoPT3 = new int[11];
        public string[] strPartNoPT3 = new string[11];
        public string[] strMachineCodePT3 = new string[11];
        public string[] strchemicalTankPT3 = new string[11];
        public string[] strchemicalTank_idPT3 = new string[11];
        public string[] stranalysisItemPT3 = new string[11];
        public double[] douTritratePT3 = new double[11];
        public string[] strWorkPT3 = new string[11];
        public string[] strRepPT3 = new string[11];
        public double[] douActualPT3 = new double[11];
        public string[] strRemarkPT3 = new string[11];

        //For Protek4
        public int[] intNoPT4 = new int[11];
        public string[] strPartNoPT4 = new string[11];
        public string[] strMachineCodePT4 = new string[11];
        public string[] strchemicalTankPT4 = new string[11];
        public string[] strchemicalTank_idPT4 = new string[11];
        public string[] stranalysisItemPT4 = new string[11];
        public double[] douTritratePT4 = new double[11];
        public string[] strWorkPT4 = new string[11];
        public string[] strRepPT4 = new string[11];
        public double[] douActualPT4 = new double[11];
        public string[] strRemarkPT4 = new string[11];

        //For Protek5
        public int[] intNoPT5 = new int[11];
        public string[] strPartNoPT5 = new string[11];
        public string[] strMachineCodePT5 = new string[11];
        public string[] strchemicalTankPT5 = new string[11];
        public string[] strchemicalTank_idPT5 = new string[11];
        public string[] stranalysisItemPT5 = new string[11];
        public double[] douTritratePT5 = new double[11];
        public string[] strWorkPT5 = new string[11];
        public string[] strRepPT5 = new string[11];
        public double[] douActualPT5 = new double[11];
        public string[] strRemarkPT5 = new string[11];

        //For Protek6
        public int[] intNoPT6 = new int[11];
        public string[] strPartNoPT6 = new string[11];
        public string[] strMachineCodePT6 = new string[11];
        public string[] strchemicalTankPT6 = new string[11];
        public string[] strchemicalTank_idPT6 = new string[11];
        public string[] stranalysisItemPT6 = new string[11];
        public double[] douTritratePT6 = new double[11];
        public string[] strWorkPT6 = new string[11];
        public string[] strRepPT6 = new string[11];
        public double[] douActualPT6 = new double[11];
        public string[] strRemarkPT6 = new string[11];

        //For Protek7
        public int[] intNoPT7 = new int[11];
        public string[] strPartNoPT7 = new string[11];
        public string[] strMachineCodePT7 = new string[11];
        public string[] strchemicalTankPT7 = new string[11];
        public string[] strchemicalTank_idPT7 = new string[11];
        public string[] stranalysisItemPT7 = new string[11];
        public double[] douTritratePT7 = new double[11];
        public string[] strWorkPT7 = new string[11];
        public string[] strRepPT7 = new string[11];
        public double[] douActualPT7 = new double[11];
        public string[] strRemarkPT7 = new string[11];

        //For Protek8
        public int[] intNoPT8 = new int[11];
        public string[] strPartNoPT8 = new string[11];
        public string[] strMachineCodePT8 = new string[11];
        public string[] strchemicalTankPT8 = new string[11];
        public string[] strchemicalTank_idPT8 = new string[11];
        public string[] stranalysisItemPT8 = new string[11];
        public double[] douTritratePT8 = new double[11];
        public string[] strWorkPT8 = new string[11];
        public string[] strRepPT8 = new string[11];
        public double[] douActualPT8 = new double[11];
        public string[] strRemarkPT8 = new string[11];

        //For Protek9A
        public int[] intNoPT9A = new int[11];
        public string[] strPartNoPT9A = new string[11];
        public string[] strMachineCodePT9A = new string[11];
        public string[] strchemicalTankPT9A = new string[11];
        public string[] strchemicalTank_idPT9A = new string[11];
        public string[] stranalysisItemPT9A = new string[11];
        public double[] douTritratePT9A = new double[11];
        public string[] strWorkPT9A = new string[11];
        public string[] strRepPT9A = new string[11];
        public double[] douActualPT9A = new double[11];
        public string[] strRemarkPT9A = new string[11];

        //For Protek9B
        public int[] intNoPT9B = new int[11];
        public string[] strPartNoPT9B = new string[11];
        public string[] strMachineCodePT9B = new string[11];
        public string[] strchemicalTankPT9B = new string[11];
        public string[] strchemicalTank_idPT9B = new string[11];
        public string[] stranalysisItemPT9B = new string[11];
        public double[] douTritratePT9B = new double[11];
        public string[] strWorkPT9B = new string[11];
        public string[] strRepPT9B = new string[11];
        public double[] douActualPT9B = new double[11];
        public string[] strRemarkPT9B = new string[11];
        //public bool[] bolSave = new bool[11];

        //public int strMaxTranID; 

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Monthly :")]
        public string START_DATED { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        [Display(Name = "End Date :")]
        public DateTime END_DATED { get; set; }


        //public int[] intTritrate = new int[11];

        //For Rep.Cal



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

        //public string[] strDailyX_Sul = new string[60];
        //public double[] douL_Sul = new double[60];
        //public double[] douM_Sul = new double[60];
        //public double[] douH_Sul = new double[60];




        //public string City { get; set; }
        //public double[] Business { get; set; }

    }

    
}