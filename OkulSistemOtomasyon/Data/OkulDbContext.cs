using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Models;
using System.IO;

namespace OkulSistemOtomasyon.Data
{
    /// <summary>
    /// Üniversite veritabanı context sınıfı
    /// </summary>
    public class OkulDbContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Akademisyen> Akademisyenler { get; set; }
        public DbSet<Bolum> Bolumler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<OgrenciNot> OgrenciNotlari { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Veritabanını uygulama klasörüne koy - TÜM KULLANICILAR AYNI VERİYİ GÖRSÜN
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string dbPath = Path.Combine(appPath, "Data", "universite.db");

                Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tablo adlarını açıkça belirt
            modelBuilder.Entity<Ogrenci>().ToTable("Ogrenciler");
            modelBuilder.Entity<Akademisyen>().ToTable("Akademisyenler");
            modelBuilder.Entity<Bolum>().ToTable("Bolumler");
            modelBuilder.Entity<Ders>().ToTable("Dersler");
            modelBuilder.Entity<OgrenciNot>().ToTable("OgrenciNotlari");
            modelBuilder.Entity<Kullanici>().ToTable("Kullanicilar");

            // İndeksler
            modelBuilder.Entity<Ogrenci>()
                .HasIndex(o => o.TC)
                .IsUnique();

            modelBuilder.Entity<Ogrenci>()
                .HasIndex(o => o.OgrenciNo)
                .IsUnique();

            modelBuilder.Entity<Akademisyen>()
                .HasIndex(a => a.TC)
                .IsUnique();

            modelBuilder.Entity<Kullanici>()
                .HasIndex(k => k.KullaniciAdi)
                .IsUnique();

            // İlişkiler
            modelBuilder.Entity<Ogrenci>()
                .HasOne(o => o.Bolum)
                .WithMany(b => b.Ogrenciler)
                .HasForeignKey(o => o.BolumId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Akademisyen>()
                .HasOne(a => a.Bolum)
                .WithMany()
                .HasForeignKey(a => a.BolumId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Ders>()
                .HasOne(d => d.Bolum)
                .WithMany(b => b.Dersler)
                .HasForeignKey(d => d.BolumId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ders>()
                .HasOne(d => d.Akademisyen)
                .WithMany(a => a.Dersler)
                .HasForeignKey(d => d.AkademisyenId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OgrenciNot>()
                .HasOne(n => n.Ogrenci)
                .WithMany(o => o.Notlar)
                .HasForeignKey(n => n.OgrenciId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OgrenciNot>()
                .HasOne(n => n.Ders)
                .WithMany(d => d.Notlar)
                .HasForeignKey(n => n.DersId)
                .OnDelete(DeleteBehavior.Cascade);

            // Danışman - Öğrenci ilişkisi
            modelBuilder.Entity<Ogrenci>()
                .HasOne(o => o.Danisman)
                .WithMany(a => a.DanismanOgrenciler)
                .HasForeignKey(o => o.DanismanId)
                .OnDelete(DeleteBehavior.SetNull);  // Akademisyen silinirse danışman NULL olur
        }
    }
}
