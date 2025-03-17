using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{
    public class PT_MC_TIN_InputResult
    {
        public PT_MC_TIN_InputResult()
        {
            this.PT_MC_TIN_InputResultList = new List<PT_MC_TIN_InputResult>();
        }
        public List<PT_MC_TIN_InputResult> PT_MC_TIN_InputResultList { get; set; }
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


        //For TIN
        public int[] intNoTIN = new int[16];
        public string[] strPartNoTIN = new string[16];
        public string[] strMachineCodeTIN = new string[16];
        public string[] strchemicalTankTIN = new string[16];
        public string[] strchemicalTank_idTIN = new string[16];
        public string[] stranalysisItemTIN = new string[16];
        public double[] douSTDTIN = new double[16];
        //public double[] douRa_valueAU = new double[20];
        //public double[] douRb_valueAU = new double[20];
        public double[] douTritrateTIN = new double[16];
        public string[] strWorkTIN = new string[16];
        public string[] strRepTIN = new string[16];
        public double[] douActualTIN = new double[16];
        public string[] strRemarkTIN = new string[16];


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


        ////1.Model for Graph Cleaner_Proselect_H

        public string[] strDailyX_Cleaner_Proselect_H = new string[] { };
        public double[] douL_Cleaner_Proselect_H = new double[] { };
        public double[] douM_Cleaner_Proselect_H = new double[] { };
        public double[] douH_Cleaner_Proselect_H = new double[] { };

        //2.Model for Graph MicroEtch_Hconc
        public string[] strDailyX_MicroEtch_Hconc = new string[] { };
        public double[] douL_MicroEtch_Hconc = new double[] { };
        public double[] douM_MicroEtch_Hconc = new double[] { };
        public double[] douH_MicroEtch_Hconc = new double[] { };

        //3.Model for Graph MicroEtch_H_Copper
        public string[] strDailyX_MicroEtch_H_Copper = new string[] { };
        public double[] douL_MicroEtch_H_Copper = new double[] { };
        public double[] douM_MicroEtch_H_Copper = new double[] { };
        public double[] douH_MicroEtch_H_Copper = new double[] { };

        //4.Model for Graph Stannatech_Tin_II
        public string[] strDailyX_Stannatech_Tin_II = new string[] { };
        public double[] douL_Stannatech_Tin_II = new double[] { };
        public double[] douM_Stannatech_Tin_II = new double[] { };
        public double[] douH_Stannatech_Tin_II = new double[] { };

        //5.Model for Graph Stannatech_Tin_IV
        public string[] strDailyX_Stannatech_Tin_IV = new string[] { };
        public double[] douL_Stannatech_Tin_IV = new double[] { };
        public double[] douM_Stannatech_Tin_IV = new double[] { };
        public double[] douH_Stannatech_Tin_IV = new double[] { };

        //6.Model for Graph Stannatech_Thiourea
        public string[] strDailyX_Stannatech_Thiourea = new string[] { };
        public double[] douL_Stannatech_Thiourea = new double[] { };
        public double[] douM_Stannatech_Thiourea = new double[] { };
        public double[] douH_Stannatech_Thiourea = new double[] { };


        //7.Model for Graph Stannatech_TotalAcid
        public string[] strDailyX_Stannatech_TotalAcid = new string[] { };
        public double[] douL_Stannatech_TotalAcid = new double[] { };
        public double[] douM_Stannatech_TotalAcid = new double[] { };
        public double[] douH_Stannatech_TotalAcid = new double[] { };



        //8.Model for Graph Stannatech_Copper
        public string[] strDailyX_Stannatech_Copper = new string[] { };
        public double[] douL_Stannatech_Copper = new double[] { };
        public double[] douM_Stannatech_Copper = new double[] { };
        public double[] douH_Stannatech_Copper = new double[] { };

        //9.Model for Graph Stannatech_AdditiveC
        public string[] strDailyX_Stannatech_AdditiveC = new string[] { };
        public double[] douL_Stannatech_AdditiveC = new double[] { };
        public double[] douM_Stannatech_AdditiveC = new double[] { };
        public double[] douH_Stannatech_AdditiveC = new double[] { };

        //10.Model for Graph Post_Immersion_Tin_Total
        public string[] strDailyX_Post_Immersion_Tin_Total = new string[] { };
        public double[] douL_Post_Immersion_Tin_Total = new double[] { };
        public double[] douM_Post_Immersion_Tin_Total = new double[] { };
        public double[] douH_Post_Immersion_Tin_Total = new double[] { };


        //11.Model for Graph Post_Immersion_Tin_Thiourea
        public string[] strDailyX_Post_Immersion_Tin_Thiourea = new string[] { };
        public double[] douL_Post_Immersion_Tin_Thiourea = new double[] { };
        public double[] douM_Post_Immersion_Tin_Thiourea = new double[] { };
        public double[] douH_Post_Immersion_Tin_Thiourea = new double[] { };

        //12.Model for Graph Post_Immersion_Tin_Copper
        public string[] strDailyX_Post_Immersion_Tin_Copper = new string[] { };
        public double[] douL_Post_Immersion_Tin_Copper = new double[] { };
        public double[] douM_Post_Immersion_Tin_Copper = new double[] { };
        public double[] douH_Post_Immersion_Tin_Copper = new double[] { };

        //13.Model for Graph lonix_SF
        public string[] strDailyX_lonix_SF = new string[] { };
        public double[] douL_lonix_SF = new double[] { };
        public double[] douM_lonix_SF = new double[] { };
        public double[] douH_lonix_SF = new double[] { };

        //14.Model for Graph PostDip270
        public string[] strDailyX_PostDip270 = new string[] { };
        public double[] douL_PostDip270 = new double[] { };
        public double[] douM_PostDip270 = new double[] { };
        public double[] douH_PostDip270 = new double[] { };

        //15.Model for Graph MicroEtch_Etch_Rate
        public string[] strDailyX_MicroEtch_Etch_Rate = new string[] { };
        public double[] douL_MicroEtch_Etch_Rate = new double[] { };
        public double[] douM_MicroEtch_Etch_Rate = new double[] { };
        public double[] douH_MicroEtch_Etch_Rate = new double[] { };

      
    }
}