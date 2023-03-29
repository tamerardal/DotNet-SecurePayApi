# DotNet-SecurePayApi Documentation

Projeye nasıl başladım?\n
  Projeye başlamadan önce proje içerisinde kullanılacak olan tablolar belirlendi. Relational Database kullanılacağı için
 tablolar arasındaki ilişkileri kod yazılmaya başlanmadan önce belirlendi. Daha sonrasında test caseleri yazıldı. Asıl projeden
 önce testler hazırlanarak projenin devamında hata olma olasılığı aza indirildi.
 
API tasarımı hakkında;\n
  API içerisinde kullanıcılar (customer), ürünler (product) ve kullanıcıların ürünleri satın aldıklarının kaydını tutan payment kısmı bulunmaktadır.
 Kullanıcılar email ve password ile kayıt olduktan sonra, Payment metodu ile önce ilgili Customer'a ait ID, daha sonra satın alacağı ürünün ID'si girilir.
 İki adet ID değeri girildikten sonra kullanıcı kredi kart bilgileri alınır. Validasyonda hata dönmediği sürece ilgili ürün, kullanıcının satın aldıkları
 kısmına eklenmiş olur.
  Customer detay kısmında ID'si alınan kullanıcının email, ad, soyad ve satın alma geçmişi görüntülenir. Payment listesi kısmında ise tüm kullanıcıların 
  ne zaman, hangi ürünü, ne kadar fiyata satın aldıkları listelenir.
    
 Kullanılan paketler;\n
  Proje içerisinde SQL sorgularını kod ile oluşturmak için Entity Framework Core paketi kullanılmıştır.
  Kullanıcının API'daki tüm alanları görüntülememesi için view modeller oluşturulmuştur. Maplemeleri ise AutoMapper paketi ile gerçekleştirilmiştir.
  Validasyonlar için Fluent Validations paketi kullanılmıştır.
  Swagger UI kullanılmıştır.
  Loglamalar yapılmış middleware ile dahil edilmiştir.
  XUnit ile testleri yazılmıştır.
