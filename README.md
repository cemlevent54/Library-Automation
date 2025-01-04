# 📚 Kütüphane Otomasyonu

Bu proje, bir kütüphanenin günlük işlemlerini otomatize etmek için geliştirilmiş bir uygulamadır. Kullanıcılar ve yöneticiler için ayrı giriş ekranları bulunmaktadır. Kullanıcılar, kitapları arayabilir, ödünç alabilir, iade edebilir ve kişisel bilgilerini güncelleyebilir veya hesaplarını silebilirler. Yöneticiler ise kullanıcıları ve kitapları yönetebilir, ödünç kitapları takip edebilir ve arşivleyebilirler.

## 🛠️ Projenin Kurulması

1. **Visual Studio'nun Kurulması:**  
   Uygulamayı geliştirmek ve çalıştırmak için [Visual Studio](https://visualstudio.microsoft.com/) yüklü olmalıdır. İlgili sürümü (Community, Professional veya Enterprise) yükleyin. .NET Framework desteği aktif olmalıdır.

2. **Projenin İndirilmesi:**  
   Projeyi indirmek için aşağıdaki komutu kullanabilirsiniz:

   ```bash
   git clone https://github.com/cemlevent54/Library-Automation.git
   ```

   **Not:** Git yüklü değilse Git'i [buradan indirip](https://git-scm.com/) kurabilirsiniz.

3. **Veritabanı Kurulumu:**
   - `db` klasöründeki `kutuphaneVeritabani.bak` dosyasını kullanarak veritabanını kurun.
   - SQL Server Management Studio (SSMS)'ı açın ve şu adımları izleyin:
     - Sol menüdeki `"Databases"` klasörüne sağ tıklayın ve `"Restore Database..."` seçeneğini seçin.
     - `"Source"` kısmında `"Device"` seçeneğini işaretleyin ve `.bak` dosyasını seçin.
     - Gerekli işlemleri tamamladıktan sonra `OK` butonuna tıklayarak veritabanını yükleyin.
4. **Veritabanı Bağlantısının Güncellenmesi:**
   - Projedeki `app.config` dosyasını açın.
   - `connectionStrings` kısmında bulunan `Data Source` değerini kendi SQL Server sunucu adı ve veritabanı adı ile değiştirin. Örnek:
   ```bash
   <connectionStrings>
   <add name="kutuphane_otomasyonu.Properties.Settings.kutuphaneVeritabaniConnectionString"
   connectionString="Data Source=XXX;Initial Catalog=kutuphaneVeritabani;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;"
   providerName="Microsoft.Data.SqlClient" />
   </connectionStrings>
   ```
   - `Data Source` kısmında `XXX` ifadesini kendi bilgisayarınızın SQL Server adı ile değiştirin.
5. **Projenin Çalıştırılması:**
   - Visual Studio'da `kutuphane_otomasyonu.sln` dosyasını açın.
   - Çözümü `(Build Solution)` derleyin ve projeyi `(Start)` çalıştırın.

## 🏠 Uygulama Giriş Ekranı

Bu ekranda Kullanıcı İşlemleri ve Yönetici İşlemleri olmak üzere iki buton vardır.
![Uygulama Giriş Ekranı](https://r.resimlink.com/38FtDA4PzR.jpg)

## 👤 Kullanıcı Giriş Ekranı

Bu ekran, kullanıcıların sisteme giriş yapabilecekleri veya yeni hesap oluşturabilecekleri işlemleri içerir.
![Kullanıcı Giriş Ekranı](https://r.resimlink.com/5E4nUy3A.jpg)

### 👥 Kullanıcı İşlemleri

- **Kitap Arama:** Kullanıcılar, kütüphanedeki kitapları aramak için bu işlemi kullanabilirler.Arama sonuçları, kitapların adı, yazarı, yayın tarihi vb. bilgileri içerir.
- **Ödünç Kitap Alma:** Kullanıcılar, istedikleri kitabı ödünç alabilirler. Ödünç alınan kitaplar, kullanıcının hesabına eklenir ve belirli bir süre sonra iade edilmek üzere işaretlenir.
- **Ödünç Kitap İade Etme:** Kullanıcılar, ödünç aldıkları kitapları iade edebilirler. İade edilen kitaplar, kullanıcının hesabından kaldırılır ve yeniden kütüphane envanterine eklenir.
- **Kullanıcı Bilgi Güncellemesi:** Kullanıcılar, kişisel bilgilerini güncelleyebilirler. Bu işlem, kullanıcının adı, e-posta adresi, telefon numarası gibi bilgileri içerir.
- **Kullanıcı Kaydını Silme:** Kullanıcılar, hesaplarını sistemden silebilirler. Bu işlem, kullanıcının tüm bilgilerini ve ödünç kitaplarını kalıcı olarak siler.

![Kullanıcı İşlemleri](https://r.resimlink.com/khYqNEZQT.jpg)

## 👨🏻‍💼 Yönetici Giriş Ekranı

Bu ekran, yöneticilerin sisteme giriş yapabilecekleri veya yeni yönetici hesapları oluşturabilecekleri işlemleri içerir.
![Yönetici Giriş Ekranı](https://r.resimlink.com/ksjhdvi2N6K.jpg)

### 💼 Yönetici İşlemleri

- **Kullanıcı Ekleme:** Yöneticiler, yeni kullanıcı hesapları oluşturabilirler. Bu işlem, kullanıcının adı, e-posta adresi, şifre gibi bilgileri içerir.
- **Kullanıcı Silme:** Yöneticiler, kullanıcı hesaplarını sistemden silebilirler.
- **Kullanıcı Görüntüleme:** Yöneticiler, tüm kullanıcıların bilgilerini görüntüleyebilirler. Bu işlem, kütüphaneye kayıtlı tüm kullanıcıların listesini ve bunların kişisel bilgilerini içerir.
- **Kitap Ekleme:** Yöneticiler, yeni kitaplar ekleyebilirler. Bu işlem, kitabın adı, yazarı, yayın tarihi, kategori gibi bilgileri içerir.
- **Kitap Silme:** Yöneticiler, kütüphaneden kitapları silebilirler. Bu işlem, belirli bir kitabın kütüphane envanterinden kalıcı olarak kaldırılmasını sağlar.
- **Kitap Görüntüleme:** Yöneticiler, mevcut kitapların listesini görüntüleyebilirler. Bu işlem, kütüphanede bulunan tüm kitapların listesini ve bunların detaylı bilgilerini içerir.
- **Ödünç Kitap Takibi:** Yöneticiler, ödünç kitapların durumunu takip edebilirler. Bu işlem, kütüphanede bulunan tüm ödünç kitapların listesini ve kimin tarafından ödünç alındığını içerir.
- **Ödünç Kitap Arşivi:** Yöneticiler, ödünç kitapların arşivini görüntüleyebilirler. Bu işlem, geçmişte iade edilmiş olan ödünç kitapların listesini içerir.

![Yönetici İşlemleri](https://r.resimlink.com/cFpOH.jpg)

## ▶️ Project Demo

## [![Watch the Project Demo](https://img.youtube.com/vi/82mglsxNeFY/0.jpg)](https://www.youtube.com/watch?v=82mglsxNeFY)
