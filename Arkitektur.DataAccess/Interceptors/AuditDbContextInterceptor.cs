using Arkitektur.Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Arkitektur.DataAccess.Interceptors
{
   public class AuthDbContextInterceptor : SaveChangesInterceptor
    {

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
            InterceptionResult<int> result, CancellationToken cancellationToken = default)
        { 
        
        foreach(var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry.Entity is not BaseEntity baseEntity) continue;

                if (entry.State is not EntityState.Added and not EntityState.Modified ) continue;

                if(entry.State is EntityState.Added)
                {
                    eventData.Context.Entry(baseEntity).Property(x => x.CreatedAt).CurrentValue = 
                        DateTime.Now;
                    eventData.Context.Entry(baseEntity).Property(x => x.UpdatedAt).IsModified =
                        false;


                }

                if(entry.State is EntityState.Modified)
                {
                    eventData.Context.Entry(baseEntity).Property(x => x.UpdatedAt).CurrentValue =
                        DateTime.Now;

                    eventData.Context.Entry(baseEntity).Property(x => x.CreatedAt).IsModified =
                        false;
                }

                
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        
        
        }
    }
}

//  EntityState.Added bir enumdur. ona göre başta karşılaştırma yapabiliyoruz.






// Şu anda senin öğrendiğin konular

//✔ async / await mantığı
//✔ Task nedir
//✔ await ne yapar
//✔ Task.Delay nasıl çalışır
//✔ Task başlatmak vs await etmek
//✔ paralel task mantığı
//✔ continuation (devam noktası)

//Bundan sonra doğal sıradaki konular

//Şimdi sırada genelde şu konular gelir:

//1️⃣ ValueTask(Task farkı)
//2️⃣ Task.Run ne zaman kullanılır
//3️⃣ ConfigureAwait(false)
//4️⃣ Parallel async pattern
//5️⃣ deadlock async hataları





//Bir konuyu bana anlatırken şu yöntemi kullan:

//Önce tam çalışan kısa bir kod örneği ver.

//Kodun çıktısını göster.

//Zaman çizelgesi (t0, t+1000ms gibi) ile adım adım ne olduğunu anlat.

//Runtime içinde gerçekte ne olduğunu mekanik olarak açıkla.

//Son olarak genel kuralı çıkar.

//Soyut tanım veya teoriden başlamayıp mutlaka önce çalışan örnekle başla.
//Eksik veya kırpılmış kod verme.
//Anlatımın sistemin iç mekanizmasını gösterecek şekilde olsun.