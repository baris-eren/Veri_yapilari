#  Online Anket ve Oy Takip Sistemi

Kullanıcıların farklı temalarda hazırlanan anketlere katılabildiği ve her kullanıcının yalnızca bir defa oy kullanmasına izin verilen bir web uygulamasıdır. Oyların yinelenmesini önlemek için çeşitli veri yapılarından faydalanılmıştır.

##  Genel Özellikler

- Her kullanıcı bir ankete yalnızca bir kez oy verebilir.
-  Anket sonuçları anlık olarak grafiksel olarak sunulur.
-  Oy tekrarı Set yapısı ile kontrol edilir.
-  Backend tarafında kontrol mekanizmaları ve doğrulama algoritmaları yer alır.
-  Tüm veriler JSON dosyalarında saklanır.

##  Teknolojiler

| Katman       | Kullanılan Teknolojiler         |
|-------------|----------------------------------|
| Backend     | C#, .NET 8, JSON veri yönetimi   |
| Frontend    | HTML, CSS                        |
| IDE         | Visual Studio Code               |
| Veri Yapıları | Set, Stack, PriorityQueue, HashSet |

##  Ekip 
- **Buse Yılmaz**
- **İbrahim Çalı**
- **Zeynep Zümral Kılıç**
- **Barış Eren**
- **Veysel Can Özkan**

## Kullanım Senaryosu

1. Kullanıcı giriş yapar veya kayıt olur.
2. Sistemden bir anket seçer ve oy verir.
3. Sistem aynı kullanıcının tekrar oy kullanmasını engeller.
4. Sonuçlar anında ekrana yansıtılır.

##  Proje Bağlantısı

GitHub üzerinde projeye buradan ulaşabilirsiniz:  
(https://github.com/baris-eren/Veri_yapilari/new/main?filename=README.md)

Bu proje; veri bütünlüğü, kullanıcı güvenliği ve görsel etkileşim açısından temel seviyede anket sistemlerinin nasıl geliştirileceğini göstermektedir.
