VFX Artist Case Study-Açıklamalar
Task 01: Kingdom - Waterfall Effect
Ocean-Pool Shader çalışmalarını shader graph üzerinden yaptıktan sonra Water Fall çalışmasını da shader graph tarafında oluşturup bunu daha optimize bir sonuç elde etmek için particle sistemde sadece material kısmına atayarak bir şelale döngüsü elde ettim.
Şelalenin havuza temas ettiği kısımlarda ise baloncuk ve köpürme, duman ve oluşan dalgaların halkalarını da particle sistem üzerinden optimize bir şekilde oluşturdum.
İlgli çalışmanın 60 FPS video çıktısı mail ekinde iletildi.

Task 02: Gameplay - Dynamite Explosion
İlgili sahneyi referansı da dikkate alarak oluşturmaya, Royal Kingdom'a olabildiğince sadık kalmaya çalışarak ilerledim.
Dinamit patlamasında kullandığım particle çalışmasını optimize bir şekilde ele aldım.
Dinamit patlamasının Match itemlarla etkileşimini sağlayabilmek ve aklımdaki senaryoyu uygulayabilmek adına karmaşık olmayacak şekilde hareketlerde birbirini tetikleyen farklı kodlar yazarak mümkün olduğunca etkileşimli bir sahne tasarladım.
Match itemların patlamalarında kullandığım sprite sheet kısmında özellikle diğer tüm çalışmalarda da dikkat ettiğim gibi mümkün olduğunca az material ve texture kullanım tekrarından kaçınarak aynı assetleri sprite sheet kısmında kullanarak,
draw call seviyesini minimumda tutarak optimizasyonu görsel kaliteden ödün vermeden sağlamış oldum.
İlgli çalışmanın 60 FPS video çıktısı mail ekinde iletildi.

Task 03: Gameplay - Rocket & Force Field
Rocket Trail çalışmasını görsel kaliteden ödün vermeden optimize bir şekilde ele aldım. Yine Match itemlarda da sprite sheet'de sadece texture bilgisine ihtiyaç duyuyorsam, default particle material kullanarak fazladan draw call maliyetinin önüne geçtim.
Bu çalışmada özellikle birbiri ardına tetiklenen bir senaryo kurguladım. İlk adımda roketin hareketi, trail çalışması, ardından roketin geçtiği yerde bulunan match itemların roketin etkisiyle patlamalarını sağladım.
Sonraki adımda kuleye çarptığı esnada kulede oluşacak bir patlama ve hemen ardından Tower Shield efektinin tetiklenmesini sağladım. Tower Shield tetiklendiği anda ayrıca Camera Shake kullanarak çarpma hissiyatını güçlendirmeyi amaçladım.
Royal Kingdom evrenine teknik ve sanatsal bütünlük içinde katkı sunmayı hedefledim. Optimizasyonu görsel kaliteden ödün vermeden dengeli çözümlerle, sağlamaya çalıştım.

Son olarak Art-Dev arasındaki iş akışlarını kolaylaştırmak, olası ihtiyaçları karşılayabilecek çözümler üretebildiğimi gösterebilmek için "Asset Importer Tool" yazdım.
Kullanışlı, basit arayüzü ve assetleri topluca hedef-kaynak dosya yollarını belirterek oyun motoruna ekleyebileceğimiz bu tool ile, tek tek eklemekle kaybedilen zamanı telafi etmek istedim arkadaşlarım için.
Oldukça verimli ve keyifli bir çalışma oldu.
![image](https://github.com/user-attachments/assets/39efb311-b087-4b2a-9959-1a50dfc373c2)
Geri bildirimlerinizi ve birlikte çalışma fırsatını heyecanla bekliyorum.
Saygılarımla,
İbrahim Altürk
Technical Artist-3D Generalist
