  ## جلسه سوم- پیاده سازی شمارنده با استفاده از  Blazor
  
 در این جلسه قصد داریم شمارنده جلسه پیش را با استفاده از Blazor  پیاده سازی کنیم. 

  وارد محیط visual studio  شده و از قسمت Get started روی گزینه create new project به منظور ایجاد پروژه جدید کلیک می‌کنیم. 
  
  
  <img width="500px" src="/images/img-1.png" />

 در مرحله بعد مطابق تصویر زیر از لیست ارایه شده ‌Blazor WebAssembly App را انتخاب و با کلیک بر روی دکمه Next به مرحله بعدی می‌رویم.
  
  <img width="500px" src="/images/img-2.png" />
  
  همان طور که در تصویر زیر می‌بینید در قسمت Project name می‌توانیم اسم پروژه را انتخاب و در قسمت Location محل قرار گیری پروژه را مشخص کنیم و اگر تیک قسمت آخر را     برداریم می‌توانیم Solution name را متفاوت از Project name تعیین کنیم.  مجددا برای رفتن به مرحله بعد بر روی دکمه Next کلیک می‌کنیم.

 <img width="500px" src="/images/img-3.png" />
 
 مطابق تصویر زیر، در این مرحله دقت کنید که Target Framework حتما روی (Net 5.0 (current قرار گرفته باشد.
 
 <img width="500px" src="/images/img-4.png" />
 
 با کلیک بر روی دکمه Create پروژه SimpleCounter  ایجاد می‌شود.
 
 همان طور که می بینید در سمت راست محیط  visual studio  ما بخش Solution Explorer  را داریم. با توجه با این نکته که ما Blazor WebAssembly App  را انتخاب کردیم ساختار فایلی که اینجا می‌بینیم مربوط به ساختار پیش فرض Blazor می‌باشد. در ابتدا ما توضیحی کوتاه و مختصر در مورد این ساختار داده و سپس بنا بر نیاز تمرین فعلی این ساختار را تغییر می‌دهیم. 
 
 <img width="300px" src="/images/img-5.png" />
 
 
 همانطور که در تصویر بالا می‌بینید ما داخل پروژه SimpleCounter.Blazor  به ترتیب پوشه‌های زیر را داریم.

پوشه Properties، داخل این پوشه یک فایل به نام launchSettings.json قرار گرفته که تنظیمات مربوط به راه اندازی سرور برنامه درآن است.


پوشه wwwroot، در این پوشه فایل های استاتیک مانند فایل های css, font, image, … قرار دارند. 

پوشه Pages، در این پوشه صفحات پروژه  با پسوند razor قرار گرفته‌اند. فایل‌هایی که دارای پسوند razor هستند شامل کدهای HTML و #C  می باشند.

پوشه Shared، در این پوشه فایل‌هایی قرار دارند که می‌توانند بین صفحات مختلف به اشتراک گذاشته شوند.

توضیحات در مورد ساختار فایل‌های پروژه برای این جلسه کافی است. همان طور که گفتیم طبق نیاز تمرین این جلسه ساختار فعلی را تغییر می دهیم. بدین ترتیب از پوشه wwwroot پوشه های css، sample-data و فایل favicon.ico رو حذف کرده و کدهای مربوط به فایل index.html رو به صورت زیر تغییر می‌دهیم.

  ```html
   
    <!DOCTYPE html>
    
    <html>
      <head>
          <meta charset="utf-8" />
          <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
          <title>SimpleCounter.Blazor</title>
          <link href="SimpleCounter.Blazor.styles.css" rel="stylesheet" />
      </head>

      <body>
          <div id="app">Loading...</div>
          <script src="_framework/blazor.webassembly.js"></script>
      </body>
    </html>
  ```

از پوشه pages  هم فایل های FetchData.razor و Index.razor  را هم حذف می‌کنیم.
 و همین طور پوشه Shared را هم حذف نمایید.
در ادامه در فایل Imports.razor_ ، به دلیل اینکه پوشه  Shared را از قبل حذف کرده ایم، خط  زیر را هم حذف می‌کنیم.


```razor
  @using simpleCounter.Blazor.Shared
```

کدهای داخل فایل App.razor  را هم به کد زیر تغییر می دهیم.


```razor
  
  <Router AppAssembly="@typeof(Program).Assembly" PreferExactMatches="@true">
      <Found Context="routeData">
          <RouteView RouteData="@routeData"/>
      </Found>
      <NotFound>
          <LayoutView>
              <p>Sorry, there's nothing at this address.</p>
          </LayoutView>
      </NotFound>
  </Router>
```

در کد بالا هم   DefaultLayout  و Layout را به دلیل حذف فایل های مربوطه حذف می‌کنیم.

برای مطمئن شدن از درستی تغییر ساختار به پوشه pages برگشته و روی فایل Counter.razor کلیک راست کرده و همانند تصویر زیر گزینه View in Browser را انتخاب می کنیم.

  <img width="300px" src="/images/img-6.png" />
  
  به دلیل این که از قبل و به صورت پیش فرض ما یک سری کد داخل فایل Counter.razor  داشتیم خروجی که در مرورگر می‌بینیم مطابق تصویر زیر است.
  
  <img width="300px" src="/images/img-7.png" />
  
  برای ایجاد شمارنده‌‌ای مطابق جلسه پیش، اما این بار با استفاده از ‌Blazor به این صورت عمل می‌کنیم.

ابتدا به فایل Counter.razor رفته و کدهای زیر را که همان کدهای فایل HTML جلسه پیش است را جایگزین کدهای فعلی می‌کنیم.

```razor
  
  @page "/counter"

  <div class="card">
      <div class="counter">
          <span id="count">0</span>
      </div>
      <div class="action">
          <button id="increase" onclick="Increase()">
              Increase
          </button>
          <button id="decrease" onclick="Decrease()">
              Deacrease
          </button>
      </div>
  </div>

  ```
  
  دقت کنید که خط اول این فایل که مسیر این فایل را در مرورگر مشخص می کند همچنان بدون تغییر باقی می‌ماند.
تغییرات را با استفاده از ctrl + s  ذخیره کرده و مجددا به مرورگر رفته و صفحه را بروزرسانی می‌کنیم.


خروجی تغییرات مطابق تصویر زیر می‌باشد.

<img width="300px" src="/images/img-8.png" />

برای افزودن کدهای css، روی پوشه pages  کلیک راست کرده، گزینه Add  را انتخاب و سپس گزینه NewItem را انتخاب می‌نماییم.

<img width="500px" src="/images/img-9.png" />

مطابق تصویر زیر از لیست ارائه شده Style Sheet  را انتخاب و در قسمت Name نامی مشابه نام Component که در اینجا Counter.razor نام دارد با پسوند css. انتخاب می کنیم.
اسم فایل Counter.razor.css می‌باشد. سپس روی دکمه Add کلیک نمایید.

<img width="500px" src="/images/img-10.png" />

فایل Counter.razor.css مشابه تصویر زیر به پروژه اضافه می‌شود.

<img width="300px" src="/images/img-11.png" />

کدهای css کپی را از فایل css جلسه گذشته کپی و در فایل Counter.css وارد می‌کنیم. 



```css
.card {
 padding: 20px;
 margin: 200px auto;
 width: 400px;
 height: 400px;
 background-color: lightskyblue;
 box-shadow: 1px 2px 10px 0 #808080;
}
 
.counter {
 margin: 50px auto;
 width: 150px;
 height: 150px;
 line-height: 150px;
 background-color: #eee;
 border-radius: 50%;
 border: 10px solid #2196f3;
 text-align: center;
 font-size: 60px;
 font-weight: bold;
 color: #1077c2;
}
 
.action {
 text-align: center;
}
 
button {
 padding: 20px 30px;
 margin: 5px;
 font-size: 24px;
 font-weight: bold;
 border-radius: 5px;
 cursor: pointer;
 color: white
}
 
#increase {
 background-color: #18cd73;
 border: 3px solid #19a35d;
}
 
#decrease {
 background-color: #ef7694;
 border: 3px solid #b74b66;
}

```

تغییرات را مجددا ذخیره و صفحه مرورگر را refresh می‌نماییم. خروجی تغییرات در مرورگر مشابه تصویر زیر می‌باشد.


<img width="400px" src="/images/img-12.png" />

در ادامه به جای افزودن کدهای Javascript برای تعیین عملکرد دکمه‌ها، از کدهای #C  استفاده می کنیم. به این صورت که مجددا روی پوشه Pages کلیک راست کرده و گزینه Add را انتخاب و سپس گزینه Class را انتخاب می کنیم. این بار فایلی با نام Counter.razor.cs ایجاد می کنیم.

کد این فایل را به کد زیر تغییر می‌دهیم.


```c#
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  namespace SimpleCounter.Blazor.Pages
  {
      public partial class Counter
      {
          public int currentCount = 0;

          public void Increase()
          {
              currentCount++;
          }

          public void Decrease()
          {
              currentCount--;
          }
      }
  }

```

  همان طور که می بینید در کلاسی به نام Counter یک متغیر به نام currentCount از نوع int که نوع عددی می باشد با مقدار اولیه " 0 " تعیین کرده‌ایم. همچنین دو متد به نام‌های Increase و Decrease که همانند جلسه گذشته، زمانی که فراخوانی می‌شوند، یک واحد به عدد ما افزوده و یا کم می‌کنند.

سپس مجددا وارد فایل Counter.razor  شده و نحوه فراخوانی متدها را تغییر می‌دهیم چرا که باید از سینتکس ‌‌Blazor که با @ مشخص میشوند استفاده کنیم.

همچنین به جای عدد صفر از نام متغیر CurrntCount استفاده می کنیم تا هر تغییر که روی عدد جاری اعمال شد مستقیما در این قسمت نمایش داده شود.

نحوه فراخوانی هر تابع روی رویداد onclick  دکمه مربوطه و استفاده از نام متغیر به جای عدد مطابق کد زیر تغییر می‌کند.


```html
<div class="card">
    <div class="counter">
        <span id="count">@currentCount</span>
    </div>
    <div class="action">
        <button id="increase" @onclick="Increase">
            Increase
        </button>
        <button id="decrease" @onclick="Decrease">
            Deacrease
        </button>
    </div>
</div>

```

تغییرات جدید را ذخیره و مجددا صفحه مرورگر را بروزرسانی نمایید.
