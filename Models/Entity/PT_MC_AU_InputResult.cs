using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{
    public class PT_MC_AU_InputResult
    {
        public PT_MC_AU_InputResult()
        {
            this.PT_MC_AU_InputResultList = new List<PT_MC_AU_InputResult>();
        }
        public List<PT_MC_AU_InputResult> PT_MC_AU_InputResultList { get; set; }
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


        //For AU
        public int[] intNoAU = new int[20];
        public string[] strPartNoAU = new string[20];
        public string[] strMachineCodeAU = new string[20];
        public string[] strchemicalTankAU = new string[20];
        public string[] strchemicalTank_idAU = new string[20];
        public string[] stranalysisItemAU = new string[20];
        public double[] douSTDAU = new double[20];
        public double[] douRa_valueAU = new double[20];
        public double[] douRb_valueAU = new double[20];
        public double[] douTritrateAU = new double[20];
        public string[] strWorkAU = new string[20];
        public string[] strRepAU = new string[20];
        public double[] douActualAU = new double[20];
        public string[] strRemarkAU = new string[20];


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


        ////1.Model for Graph Cleaner_ACL_009

        public string[] strDailyX_Cleaner_ACL_009 = new string[] { };
        public double[] douL_Cleaner_ACL_009 = new double[] { };
        public double[] douM_Cleaner_ACL_009 = new double[] { };
        public double[] douH_Cleaner_ACL_009 = new double[] { };

        //2.Model for Graph Aciddip1
        public string[] strDailyX_Aciddip1 = new string[] { };
        public double[] douL_Aciddip1 = new double[] { };
        public double[] douM_Aciddip1 = new double[] { };
        public double[] douH_Aciddip1 = new double[] { };

        //3.Model for Graph Aciddip2
        public string[] strDailyX_Aciddip2 = new string[] { };
        public double[] douL_Aciddip2 = new double[] { };
        public double[] douM_Aciddip2 = new double[] { };
        public double[] douH_Aciddip2 = new double[] { };

        //4.Model for Graph Predip
        public string[] strDailyX_Predip = new string[] { };
        public double[] douL_Predip = new double[] { };
        public double[] douM_Predip = new double[] { };
        public double[] douH_Predip = new double[] { };

        //5.Model for Graph SoftEtch_APS
        public string[] strDailyX_SoftEtch_APS = new string[] { };
        public double[] douL_SoftEtch_APS = new double[] { };
        public double[] douM_SoftEtch_APS = new double[] { };
        public double[] douH_SoftEtch_APS = new double[] { };

        //6.Model for Graph SoftEtch_H2SO4
        public string[] strDailyX_SoftEtch_H2SO4 = new string[] { };
        public double[] douL_SoftEtch_H2SO4 = new double[] { };
        public double[] douM_SoftEtch_H2SO4 = new double[] { };
        public double[] douH_SoftEtch_H2SO4 = new double[] { };


        //7.Model for Graph SoftEtch_Copper
        public string[] strDailyX_SoftEtch_Copper = new string[] { };
        public double[] douL_SoftEtch_Copper = new double[] { };
        public double[] douM_SoftEtch_Copper = new double[] { };
        public double[] douH_SoftEtch_Copper = new double[] { };



        //8.Model for Graph KAT_450_Pd
        public string[] strDailyX_KAT_450_Pd = new string[] { };
        public double[] douL_KAT_450_Pd = new double[] { };
        public double[] douM_KAT_450_Pd = new double[] { };
        public double[] douH_KAT_450_Pd = new double[] { };

        //9.Model for Graph KAT_450_H2SO4
        public string[] strDailyX_KAT_450_H2SO4 = new string[] { };
        public double[] douL_KAT_450_H2SO4 = new double[] { };
        public double[] douM_KAT_450_H2SO4 = new double[] { };
        public double[] douH_KAT_450_H2SO4 = new double[] { };

        //10.Model for Graph KAT_450_Copper
        public string[] strDailyX_KAT_450_Copper = new string[] { };
        public double[] douL_KAT_450_Copper = new double[] { };
        public double[] douM_KAT_450_Copper = new double[] { };
        public double[] douH_KAT_450_Copper = new double[] { };


        //11.Model for Graph Electroless_Ni_pH
        public string[] strDailyX_Electroless_Ni_pH = new string[] { };
        public double[] douL_Electroless_Ni_pH = new double[] { };
        public double[] douM_Electroless_Ni_pH = new double[] { };
        public double[] douH_Electroless_Ni_pH = new double[] { };

        //12.Model for Graph Electroless_Ni_Ni_Ion
        public string[] strDailyX_Electroless_Ni_Ni_Ion = new string[] { };
        public double[] douL_Electroless_Ni_Ni_Ion = new double[] { };
        public double[] douM_Electroless_Ni_Ni_Ion = new double[] { };
        public double[] douH_Electroless_Ni_Ni_Ion = new double[] { };

        //13.Model for Graph Electroless_Ni_Shy
        public string[] strDailyX_Electroless_Ni_Shy = new string[] { };
        public double[] douL_Electroless_Ni_Shy = new double[] { };
        public double[] douM_Electroless_Ni_Shy = new double[] { };
        public double[] douH_Electroless_Ni_Shy = new double[] { };

        //14.Model for Graph Au_pH
        public string[] strDailyX_Au_pH = new string[] { };
        public double[] douL_Au_pH = new double[] { };
        public double[] douM_Au_pH = new double[] { };
        public double[] douH_Au_pH = new double[] { };

        //15.Model for Graph Au
        public string[] strDailyX_Au = new string[] { };
        public double[] douL_Au = new double[] { };
        public double[] douM_Au = new double[] { };
        public double[] douH_Au = new double[] { };

        //16.Model for Graph CN
        public string[] strDailyX_CN = new string[] { };
        public double[] douL_CN = new double[] { };
        public double[] douM_CN = new double[] { };
        public double[] douH_CN = new double[] { };

        //17.Model for Graph Au_TSB_71_B
        public string[] strDailyX_Au_TSB_71_B = new string[] { };
        public double[] douL_Au_TSB_71_B = new double[] { };
        public double[] douM_Au_TSB_71_B = new double[] { };
        public double[] douH_Au_TSB_71_B = new double[] { };

        //18.Model for Graph Au_TSB_71_M20
        public string[] strDailyX_Au_TSB_71_M20 = new string[] { };
        public double[] douL_Au_TSB_71_M20 = new double[] { };
        public double[] douM_Au_TSB_71_M20 = new double[] { };
        public double[] douH_Au_TSB_71_M20 = new double[] { };

        //19.Model for Graph Electroless_Ni_Cu
        //20.Model for Graph Au_Ni
        //21.Model for Graph Etching_Rate

        //22.Model for Graph Au_TSB_71_R1
        public string[] strDailyX_Au_TSB_71_R1 = new string[] { };
        public double[] douL_Au_TSB_71_R1 = new double[] { };
        public double[] douM_Au_TSB_71_R1 = new double[] { };
        public double[] douH_Au_TSB_71_R1 = new double[] { };


        //23.Model for Graph Au_A_Value
        public string[] strDailyX_Au_A_Value = new string[] { };
        public double[] douL_Au_A_Value = new double[] { };
        public double[] douM_Au_A_Value = new double[] { };
        public double[] douH_Au_A_Value = new double[] { };
    }
}