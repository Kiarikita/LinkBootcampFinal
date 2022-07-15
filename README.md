# Link Bilgisayar Bootcamp Project / Müşteri Kayıt Rehberi Uygulaması
**Proje:**
-	Müşterilerimizin tüm kayıtlarını tutulabilecek,
-   İstenilen özel koşullara göre rapor oluşturulabilecek(aylık, haftalık vb),
-	Raporları istenildiği takdirde indirmesi sağlanacak,
-	Raporlar excel olarak aktarılabilecek 

maddeleri amaçlamaktadır. 


## Yol haritası

**Planlama :** 

    1. Gönderilen doküman tasarım dokümanı olarak kabul edildi.

**Analiz :** 

    1. ORM aracına karar verilmesi ve kurulması
    2. Tablolar için gerekli entitylerin oluşturulması 
    3. Geliştirme ortamına ve geliştirme diline karar verilmesi
    4. Projenin katmanların oluşturulması
    5. Repository Design Pattern implementasyonunun yapılması
    6. Veritabanı configurasyonunun yapılması
    7. Endpointlerin hazırlanması
    8. Endpointlerin Postman ile test edilmesi
    9. Güvenlik mekanızmasının kurulması (Token, refresh token)
    10. Rol bazlı yetkilendirme yapılması
    11. Müşteri fotoğraflarına filigran (watermark) eklenmesi
    12. Raporlarını oluşturulması
    13. Raporların indirilebilir olması

**Tasarım :**

    14. N-Layer mimari kullanılacak
    15. EF Core kullanılacak
    16. C# .Net Core kullanılacak
    17. Postgre SQL kullanılacak
    18. Quartz Library kullanılacak
    19. RabbitMQ kullanılacak
    20. Source control olarak Git kullanılacak


**Uygulama :**

    21. Geliştirmeler feature olarak jira ya girilecek ve buradan takibi yapılacak
    22. Geliştirmeler git ile geliştirilecek Developer, Production ortamları olacak 
    23. Geliştirmeler ilk olarak developer ortamına deploy edilecekve sonrasında production ortamına aktarılacak

**Bakım :**

    24. İş akışının tekrarı ve iyileştirilmesi



## Kullanılan Teknolojiler
-   **Veritabanı :** PostgreSQL
-	**Proje :** Asp.Net Core API
-	**Rapor :** Quartz Library
-	**Message Broker :** RabbitMQ




  
