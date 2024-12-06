KÜTÜPHANE YÖNETİM SİSTEMİ
========================

PROJE HAKKINDA:
---------------
Kütüphane Yönetim Sistemi, bir kütüphanenin kitap ve yazar işlemlerini yönetmek için geliştirilmiş bir ASP.NET Core MVC uygulamasıdır. Bu sistem sayesinde kitap ve yazarlar üzerinde listeleme, ekleme, düzenleme ve silme gibi işlemler kolayca gerçekleştirilebilir.

PROJE ÖZELLİKLERİ:
------------------
1. Kitap Yönetimi:
   - Kitapları listeleyebilme.
   - Yeni kitap ekleyebilme.
   - Mevcut kitap bilgilerini düzenleyebilme.
   - Kitapları silebilme.

2. Yazar Yönetimi:
   - Yazarları listeleyebilme.
   - Yeni yazar ekleyebilme.
   - Mevcut yazar bilgilerini düzenleyebilme.
   - Yazarları silebilme.

3. Ana Sayfa ve Hakkında Sayfası:
   - Kullanıcı dostu bir giriş sayfası.
   - Projenin amacı ve detaylarını içeren bir "Hakkında" sayfası.

4. Responsive Tasarım:
   - Layout ve Footer gibi sabit bileşenler.
   - PartialView kullanımı.

5. Routing ve Statik Dosya Yönetimi:
   - Varsayılan routing ayarları.
   - Statik dosya desteği.

KURULUM ADIMLARI:
-----------------
1. Projeyi Klonlayın:
   git clone https://github.com/kullanıcıadı/MvcProject1.git
   cd kutuphane-yonetim-sistemi

2. Gerekli Paketleri Yükleyin:
   Visual Studio'da Tools > NuGet Package Manager > Manage NuGet Packages for Solution seçeneğini kullanarak gerekli bağımlılıkları yükleyin.

3. Veritabanını Yapılandırın:
   - appsettings.json dosyasındaki veritabanı bağlantı ayarlarını düzenleyin.
   - Migration işlemlerini tamamlayın:
     dotnet ef migrations add InitialCreate
     dotnet ef database update

4. Uygulamayı Çalıştırın:
   Visual Studio'da Run tuşuna basarak veya aşağıdaki komutla:
     dotnet run

5. Uygulamayı Tarayıcıda Açın:
   Varsayılan olarak http://localhost:5000 adresinde çalışır.

PROJE YAPISI:
-------------
- MODELS:
  Kitap ve yazar verilerini temsil eden sınıflar (Book, Author).

- VIEWMODELS:
  Kitap ve yazar verilerini View katmanında kullanmak için tasarlanan veri transfer sınıfları.

- CONTROLLERS:
  İş mantığını yöneten ve veri akışını sağlayan sınıflar (BookController, AuthorController).

- VIEWS:
  Kullanıcı arayüzünü oluşturan dosyalar (List, Create, Edit, Details).

- WWWROOT:
  Statik dosyalar (CSS, JS, görüntüler).

ÖZELLİKLER VE SAYFALAR:
-----------------------
1. KITAP İŞLEMLERİ:
   - List: Kitapların listesini gösterir. Silme işlemi de yapılabilir.
   - Details: Seçilen kitabın detaylarını görüntüler.
   - Create: Yeni bir kitap eklemek için form sağlar.
   - Edit: Mevcut bir kitabı düzenlemek için form sağlar.

2. YAZAR İŞLEMLERİ:
   - List: Yazarların listesini gösterir. Silme işlemi de yapılabilir.
   - Details: Seçilen yazarın detaylarını görüntüler.
   - Create: Yeni bir yazar eklemek için form sağlar.
   - Edit: Mevcut bir yazarı düzenlemek için form sağlar.

3. DİĞER SAYFALAR:
   - Ana Sayfa: Projenin giriş sayfası.
   - Hakkında: Projenin amacı ve detaylarını içeren bir sayfa.

FOOTER:
-------
Tüm sayfaların altında sabit bir şekilde şu metin yer alır:
   © 2024 Kütüphane Yönetim Sistemi. Tüm hakları saklıdır.

KATKIDA BULUNMA:
----------------
Bu projeye katkıda bulunmak için lütfen bir pull request gönderin veya bir issue açın.

LİSANS:
-------
Bu proje MIT lisansı altında lisanslanmıştır. Daha fazla bilgi için LICENSE dosyasına bakabilirsiniz.
