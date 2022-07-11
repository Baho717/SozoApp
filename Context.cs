using Microsoft.EntityFrameworkCore;
using SozoApothecary.Models;

namespace SozoApothecary;

public class Context : DbContext
{
   public Context() : base(){}
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(@"Data Source=SozoApothecary.db");
    }

   public DbSet<Models.CurrentMedication>? CurrentMedications {get;set;}
   public DbSet<DoctorsAppointment>? DoctorsAppointments {get;set;}
    public DbSet<MedicationHistory>? MedicationHistories {get;set;}
    public DbSet<VisitLog>? VisitLogs {get;set;}
}