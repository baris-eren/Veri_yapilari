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

### Frontend Ekibi
- **Buse Yılmaz**: Kullanıcı arayüzü tasarımı (anket sayfası, giriş ekranı)
- **İbrahim Çalı**: Sonuç ekranı, frontend testleri, hata ayıklama

### Backend Ekibi
- **Zeynep Zümral Kılıç**: Giriş/doğrulama sistemi, eşsiz oy kaydı
- **Barış Eren**: Frontend-backend entegrasyonu, anket sonuçlarının yönetimi
- **Veysel Can Özkan**: Kontrol algoritmaları, backend birim testleri

## Kullanılan Algoritmalar Ve Karmaşıklıkları
1. Priority queue (anketleri oy sayısına göre sıralamak için) zaman karmaşıklığı O(nlogn)
2. HashSet(benzersiz kullanıcı adı tutmak) zaman karmaşıklığı O(n)
3. Set (oy tekrarını önlemek amacıyla) zaman karmaşıklığı O(1)
4. Stack (bir seçeneği geri alma işlemi) zaman karmaşıklığı O(1)

## Kullanım Senaryosu

1. Kullanıcı giriş yapar veya kayıt olur.
2. Sistemden bir anket seçer ve oy verir.
3. Sistem aynı kullanıcının tekrar oy kullanmasını engeller.
4. Sonuçlar anında ekrana yansıtılır.


##  Proje Bağlantısı

GitHub üzerinde projeye buradan ulaşabilirsiniz:  
(https://github.com/baris-eren/Veri_yapilari)

Bu proje; veri bütünlüğü, kullanıcı güvenliği ve görsel etkileşim açısından temel seviyede anket sistemlerinin nasıl geliştirileceğini göstermektedir.
