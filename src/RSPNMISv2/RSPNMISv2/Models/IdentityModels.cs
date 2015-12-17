using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace RSPNMISv2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.CommandTimeout = 300; //5 Mins
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<PartnerOrganization> PartnerOrganizations { set; get; }
        public DbSet<Indicator> Indicators { set; get; }
        public DbSet<District> Districts { set; get; }
        public DbSet<UC> UCs { set; get; }
        public DbSet<RSPOutreach> RSPOutreachs { set; get; }
        public DbSet<ProjectDistrict> ProjectDistricts { set; get; }
        public DbSet<Province> Provinces { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Using Fluent API for fine control
            // https://msdn.microsoft.com/en-us/data/jj591617.aspx

            modelBuilder.Entity<RSPOutreach>().Property(x => x.Value).HasPrecision(18, 2);
            modelBuilder.Entity<RSPOutreach>().HasIndex("Index_RSPOutreach_Dist_Id", e => e.Property(x => x.Dist_Id));
            modelBuilder.Entity<RSPOutreach>().HasIndex("Index_RSPOutreach_UC_Id", e => e.Property(x => x.UC_Id));

            base.OnModelCreating(modelBuilder);
        }
    }
    public class PartnerOrganization
    {
        public PartnerOrganization()
        {
            OrderIndex = 1000;
            IsActive = true;

        }
        [Key]
        [Required]
        public int ID { set; get; }
        public int PartnerOrganizationType_ID { set; get; }
        [StringLength(250)]
        public string Abbr { set; get; }
        [StringLength(250)]
        public string Title { set; get; }
        [StringLength(250)]
        public string Description { set; get; }
        public Nullable<int> YearFounded { set; get; }
        [StringLength(7)]
        public string ColorCode { set; get; }
        public long OrderIndex { set; get; }
        public bool IsActive { set; get; }
    }
    public class Indicator
    {
        public Indicator()
        {
            OrderIndex = 1000;
            IsActive = true;
            IsCumulative = false;
            SumOverlapping = true;
        }
        [Key]
        [Display(Name = "ID")]
        public int ID { set; get; }
        [StringLength(250)]
        public string IndicatorName { set; get; }
        [StringLength(250)]
        public string SubIndicatorName { set; get; }
        public long OrderIndex { set; get; }
        public bool IsActive { set; get; }

        public DateTime DateCreated { set; get; }
        [Required]
        [StringLength(250)]
        public string CreatedBy { set; get; }
        public DateTime DateModified { set; get; }
        [Required]
        [StringLength(250)]
        public string ModifiedBy { set; get; }

        public bool IsCumulative { set; get; } // true if RSP Sends data cumulatively without Districts
        public bool ShowVarianceInReports { set; get; } // if Variance is needed in Report
        public bool SumOverlapping { set; get; } // if Variance is needed in Report

    }
    public class District
    {

        [StringLength(250)]
        public string District_Name { set; get; }
        [StringLength(250)]
        public string AlternateName { set; get; }
        [StringLength(250)]
        public string PROVINCE { set; get; }
        public Nullable<int> Prov_Id { set; get; }
        [StringLength(250)]
        public string Country { set; get; }
        [Key]
        [Display(Name = "ID")]
        public int Dist_Id { set; get; }
    }
    public class UC
    {
        [StringLength(250)]
        public string UC_Name { set; get; }
        [StringLength(250)]
        public string Thesil { set; get; }
        [StringLength(250)]
        public string District { set; get; }
        [StringLength(250)]
        public string PROVINCE { set; get; }
        public Nullable<int> Prov_Id { set; get; }
        [StringLength(250)]
        public string Country { set; get; }
        public Nullable<int> Dist_Id { set; get; }
        public Nullable<int> Teh_Id { set; get; }
        [Key]
        [Display(Name = "ID")]
        public int UC_Id { set; get; }

    }
    public class RSPOutreach
    {
        public RSPOutreach()
        {
            IsCumulative = false;
        }


        [Key]
        [Display(Name = "ID")]
        public int ID { set; get; }
        [ForeignKey("Indicator")]
        public int IndicatorID { set; get; }
        public virtual Indicator Indicator { set; get; }
        public Nullable<DateTime> ReportingDate { set; get; }
        public Nullable<decimal> Value { set; get; }

        [ForeignKey("District")] //This column is null-able since RSPs may send data cumulatively for all Districts
        public Nullable<int> Dist_Id { set; get; }
        public virtual District District { set; get; }

        [ForeignKey("UC")]
        public Nullable<int> UC_Id { set; get; }
        public virtual UC UC { set; get; }

        public DateTime DateCreated { set; get; }
        [Required]
        [StringLength(250)]
        public string CreatedBy { set; get; }
        public DateTime DateModified { set; get; }
        [Required]
        [StringLength(250)]
        public string ModifiedBy { set; get; }

        [ForeignKey("PartnerOrganization")]
        public Nullable<int> PartnerOrganizationID { set; get; }
        public virtual PartnerOrganization PartnerOrganization { set; get; }

        public bool IsCumulative { set; get; } // true if RSP Sends data cumulatively without Districts
      
        
    }

    public class Province
    {
        [StringLength(250)]
        public string PROVINCE { set; get; }

        [Key]
        [Display(Name = "ID")]
        public int Prov_Id { set; get; }

        [StringLength(250)]
        public string Country { set; get; }
    }

    public class ProjectDistrict
    {

        [Key]
        [Display(Name = "ID")]
        public int ID { set; get; }

        [ForeignKey("PartnerOrganization")]
        public int PartnerOrganizationID { set; get; }
        public virtual PartnerOrganization PartnerOrganization { set; get; }

        [ForeignKey("District")]
        public int Dist_Id { set; get; }
        public virtual District District { set; get; }
    }


  

}