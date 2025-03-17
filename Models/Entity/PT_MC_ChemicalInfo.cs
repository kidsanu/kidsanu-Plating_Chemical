using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace WebApplication2.Models.Entity
{
    public class PT_MC_ChemicalInfo
    {
        public PT_MC_ChemicalInfo()
        {
            this.PT_MC_List = new List<PT_MC_ChemicalInfo>();
        }
        public List<PT_MC_ChemicalInfo> PT_MC_List { get; set; }
        [Display(Name = "Part No. :")]
        public string PART_NO { get; set; }
        [Display(Name = "Machine Code :")]
        public string MACHINE_CODE { get; set; }
        [Display(Name = "Chemical Name :")]
        public string CHEMICAL_NAME { get; set; }
        [Display(Name = "Chemical Tank :")]
        public string CHEMICAL_TANK { get; set; }
        [Display(Name = "UoM :")]
        public string UNIT_MEAS { get; set; }
        [Display(Name = "Volume :")]
        public decimal VOL { get; set; }
        [Display(Name = "High control range :")]
        public decimal CTRL_HIGH { get; set; }
        [Display(Name = "Action High :")]
        public decimal ACT_HIGH { get; set; }
        [Display(Name = "Median control range :")]
        public decimal CTRL_MEDIAN { get; set; }
        [Display(Name = "Action chemical supply :")]
        public decimal ACT_CHE_SPY { get; set; }
        [Display(Name = "Action Low :")]
        public decimal ACT_LOW { get; set; }
        [Display(Name = "Low control range :")]
        public decimal CTRL_LOW { get; set; }
        [Display(Name = "Optimum value :")]
        public decimal OPTIMUM { get; set; }
        [Display(Name = "Replenishment calculation :")]
        public decimal REP_POINT { get; set; }
        [Display(Name = "Working formula :")]
        public string WORK_FORMULA { get; set; }
        [Display(Name = "Replenishment formula :")]
        public string REP_FORMULA { get; set; }
        [Display(Name = "Remark :")]
        public string REMARK { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        [Display(Name = "Revise Date :")]
        public DateTime REVISE_DATE { get; set; }
        [Display(Name = "Revise by :")]
        public string REVISE_BY { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        [Display(Name = "Create Date :")]
        public DateTime CREATE_DATE { get; set; }



    }
}