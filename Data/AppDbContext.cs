using Microsoft.EntityFrameworkCore;
using real_estate.Models;

namespace real_estate.Data
{
    public class AppDbContext:DbContext
    {
        // اللي فهمت احنا نخلي الكلاس يرث من الانتتي فريم كور عشان يشغل كلاساته و بالخطوة الثانية سوينا اوبجيكت من احد كلاساته عشان يعبي البيانات فيه و خليناه يرسل البيانات للكلاس للدالة الام اللي بالبداية ورث منها الكلاس
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            

        }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Agreement> agreement { get; set; }
        public DbSet<Apartments> apartments { get; set; }
        public DbSet<Client> client { get; set; }
        public DbSet<Features> features { get; set; }
        public DbSet<Houses> houses { get; set; }
        public DbSet<Property> property { get; set; }
        public DbSet<Property_image> property_image { get; set; }
    }
}
