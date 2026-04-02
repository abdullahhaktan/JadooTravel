# 🌍 Jadoo Travel – AI-Powered Vacation Reservation Platform with MongoDB

> MongoDB veritabanı ve yapay zeka entegrasyonu ile geliştirilmiş çok dilli modern tatil rezervasyon platformu  
> A modern multilingual vacation reservation platform powered by MongoDB and AI integration

[![.NET](https://img.shields.io/badge/.NET-ASP.NET_Core-512bd4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Database](https://img.shields.io/badge/Database-MongoDB-47A248?logo=mongodb)](https://mongodb.com/)
[![Language](https://img.shields.io/badge/Language-C%23-blue.svg)](https://learn.microsoft.com/dotnet/csharp/)
[![Mapping](https://img.shields.io/badge/Mapping-AutoMapper-red.svg)](https://automapper.org/)
[![Localization](https://img.shields.io/badge/Localization-RESX-orange.svg)]()

---

## 🚀 Özellikler / Features

| 🇹🇷 Türkçe | 🇬🇧 English |
|-----------|------------|
| MongoDB NoSQL veri yönetimi | MongoDB NoSQL data management |
| AI destekli öneri sistemi | AI-powered recommendation system |
| Çok dilli içerik yönetimi (4 dil) | Multi-language content support (4 languages) |
| Katmanlı mimari yapı | Layered architecture |
| ViewComponent tabanlı modüler UI | Modular UI via ViewComponents |
| DTO & AutoMapper veri eşleme | DTO & AutoMapper mapping |
| Admin & Public tema ayrımı | Admin & Public theme separation |
| Dependency Injection mimarisi | Dependency Injection architecture |

---

## 🌐 Çoklu Dil Desteği / Multilingual Support

Proje aşağıdaki dilleri desteklemektedir:

🇹🇷 Türkçe  
🇬🇧 English  
🇪🇸 Español  
🇫🇷 Français  

Localization işlemleri **.resx resource files** üzerinden yönetilmektedir.

Provides scalable multilingual architecture via resource-based localization.

---

## 🤖 AI Entegrasyonu / AI Integration

Platform içerisinde yapay zeka destekli öneri mekanizması bulunmaktadır:

✔ Şehir bazlı öneriler  
✔ Ülke bazlı gezi tavsiyeleri  
✔ Kullanıcıya özel tur içerikleri  

Enhances user experience through intelligent travel recommendations.

---

## 🏗️ Mimari / Architecture

```
JadooTravelProject/
├── Controllers/
│
├── Services/
│
├── Models/
│
├── DTOs/
│
├── ViewComponents/
│
├── Themes/
│   ├── Public/
│   └── Admin (Spike Theme)
│
├── Localization/
│
└── wwwroot/
```

Katmanlı mimari sayesinde proje sürdürülebilir ve genişletilebilir hale getirilmiştir.

---

## 🧩 Kullanılan Tasarım Yaklaşımları / Design Approaches

### Layered Architecture

Controller → Service → Model katman ayrımı uygulanmıştır.

Ensures maintainable architecture separation.

---

### Dependency Injection

Loose coupling prensibi uygulanmıştır.

Improves scalability and testability.

---

### DTO Pattern

Katmanlar arası veri transferi güvenli hale getirilmiştir.

Prevents unnecessary data exposure between layers.

---

### AutoMapper Integration

Mapping işlemleri otomatik hale getirilmiştir.

Reduces boilerplate code significantly.

---

### ViewComponent Structure

Tekrarlayan UI bileşenleri modüler hale getirilmiştir.

Improves UI maintainability.

---

## 🗄️ MongoDB Veri Yönetimi / MongoDB Data Management

Projede relational database yerine **MongoDB NoSQL yaklaşımı** tercih edilmiştir.

✔ Flexible schema  
✔ High performance document storage  
✔ Scalable architecture support  

Provides modern document-based data architecture.

---

## 🎨 Tema Yapısı / Theme Architecture

Projede iki farklı arayüz yapısı bulunmaktadır:

### Public Theme

Kullanıcıların tur içeriklerini görüntülediği arayüz

User-facing vacation browsing interface

---

### Spike Admin Theme

Sistem yönetimi için kullanılan admin panel

Administrative management interface

---

## 👤 Kullanıcı Özellikleri / User Features

✔ Hızlı rezervasyon sistemi  
✔ Güncel tur listeleme  
✔ Şehir bazlı öneriler  
✔ Ülke bazlı öneriler  
✔ Admin panel yönetimi  

Provides a complete reservation lifecycle experience.

---

## 🛠️ Kullanılan Teknolojiler / Tech Stack

| Katman / Layer | Teknoloji |
|---------------|-----------|
| Backend | ASP.NET Core MVC |
| Database | MongoDB |
| Mapping | AutoMapper |
| Localization | RESX Resource Files |
| Architecture | Layered Architecture |
| UI Structure | ViewComponents |
| Dependency Management | Dependency Injection |
| Language | C# |

---

## ⚙️ Kurulum / Setup

### Gereksinimler / Requirements

- .NET SDK
- MongoDB
- Visual Studio 2022+

---

### Adımlar / Steps

```bash
git clone https://github.com/username/JadooTravelProject.git
cd JadooTravelProject
```

**MongoDB bağlantısını appsettings.json içinde güncelleyin**

```
MongoDbSettings:
 ConnectionString=YOUR_CONNECTION
 DatabaseName=JadooTravelDb
```

**Projeyi başlatın**

```
dotnet run
```

---

## 📊 Proje Vizyonu / Project Vision

Bu proje modern rezervasyon sistemlerinin temel bileşenlerini göstermektedir:

✔ MongoDB document database architecture  
✔ AI-supported recommendation system  
✔ Multilingual localization infrastructure  
✔ Admin & public UI separation  

This project demonstrates a scalable **AI-enhanced multilingual travel reservation platform architecture**.

---

## 📸 Screenshots

<img src="https://github.com/user-attachments/assets/32e940d5-4084-4755-940a-ddcc4e91dd17" />

---

<img src="https://github.com/user-attachments/assets/2f40af40-aeed-489e-9d90-ee78304670c1" />

--

<img src="https://github.com/user-attachments/assets/4c6198f2-94b7-4be0-a6f3-98e6bc4e9c43" />

---

<img src="https://github.com/user-attachments/assets/e610400d-e8a8-470c-a5c0-717f87bc8fd6" />

---

<img src="https://github.com/user-attachments/assets/c51ed695-23af-4c6e-861d-bda9a5a4ed9d" />

---

<img src="https://github.com/user-attachments/assets/128db4f6-0f94-4151-97bd-30ef8c655d4c" />

---

<img src="https://github.com/user-attachments/assets/23822e77-5f54-479b-8769-af6d30a7c1a5" />

---

<img src="https://github.com/user-attachments/assets/de69a853-508f-4695-a861-0eff2857c8fc" />

---

<img src="https://github.com/user-attachments/assets/2a077a40-58f6-48e4-883c-fce89fa49199" />

---

<img src="https://github.com/user-attachments/assets/5721441b-f8d0-4850-81bf-5af89549a9e2" />

---

## 👨‍💻 Developer

**Abdullah Haktan**

GitHub → https://github.com/abdullahhaktan
