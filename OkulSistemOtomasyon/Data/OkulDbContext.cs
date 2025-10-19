using Microsoft.EntityFrameworkCore;
using OkulSistemOtomasyon.Models;
using System.IO;

namespace OkulSistemOtomasyon.Data
{
    /// <summary>
    /// Veritabanı context sınıfı
    /// </summary>
    public class OkulDbContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }
        public DbSet<Sinif> Siniflar { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<OgrenciNot> OgrenciNotlar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "OkulSistem",
                    "okulsistem.db"
                );

                // Klasörü oluştur
                Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İndeksler
            modelBuilder.Entity<Ogrenci>()
                .HasIndex(o => o.TC)
                .IsUnique();

            modelBuilder.Entity<Ogretmen>()
                .HasIndex(o => o.TC)
                .IsUnique();

            modelBuilder.Entity<Kullanici>()
                .HasIndex(k => k.KullaniciAdi)
                .IsUnique();

            // İlişkiler
            modelBuilder.Entity<Ogrenci>()
                .HasOne(o => o.Sinif)
                .WithMany(s => s.Ogrenciler)
                .HasForeignKey(o => o.SinifId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ders>()
                .HasOne(d => d.Sinif)
                .WithMany(s => s.Dersler)
                .HasForeignKey(d => d.SinifId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ders>()
                .HasOne(d => d.Ogretmen)
                .WithMany(o => o.Dersler)
                .HasForeignKey(d => d.OgretmenId)
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

            // Seed Data - Varsayılan admin kullanıcı
            modelBuilder.Entity<Kullanici>().HasData(
                new Kullanici
                {
                    KullaniciId = 1,
                    KullaniciAdi = "admin",
                    Sifre = "admin123", // Gerçek uygulamada hash'lenmiş olmalı
                    Ad = "Admin",
                    Soyad = "User",
                    Email = "admin@okulsistem.com",
                    Rol = "Admin",
                    OlusturmaTarihi = DateTime.Now,
                    Aktif = true
                }
            );

            // Seed Data - Örnek sınıflar
            modelBuilder.Entity<Sinif>().HasData(
                new Sinif { SinifId = 1, SinifAdi = "9-A", Seviye = 9, Sube = "A", Kontenjan = 30, DersYili = "2024-2025", Aktif = true },
                new Sinif { SinifId = 2, SinifAdi = "9-B", Seviye = 9, Sube = "B", Kontenjan = 30, DersYili = "2024-2025", Aktif = true },
                new Sinif { SinifId = 3, SinifAdi = "10-A", Seviye = 10, Sube = "A", Kontenjan = 30, DersYili = "2024-2025", Aktif = true },
                new Sinif { SinifId = 4, SinifAdi = "11-A", Seviye = 11, Sube = "A", Kontenjan = 30, DersYili = "2024-2025", Aktif = true },
                new Sinif { SinifId = 5, SinifAdi = "12-A", Seviye = 12, Sube = "A", Kontenjan = 30, DersYili = "2024-2025", Aktif = true }
            );
        }
    }
}
