
<div dir="rtl">
  
## جلسه پنجم- پیاده سازی صفحه Login
  
در این جلسه قصد داریم صفحه Login پروژه اصلی این دوره (TaskManagement) را به صورت Responsive پیاده سازی کنیم.

در زمان نه چندان دور کاربران فقط از طریق Desktop computer ها به وب‌سایت‌ها دسترسی پیدا می‌کردند. اکثرا هم مانیتورهای یکسانی داشتند، اما امروزه کاربران از طریق دستگاه‌های متفاوت با صفحه نمایش‌های چند اینچ تا ۲۷ اینچ یا حتی بیشتر، به وب‌سایت‌ها دسترسی پیدا می‌کنند و به طبع این کاربران انتظار دارند، وب‌‌سایتی که از آن بازدید می‌کنند با دستگاه مورد استفاده‌شان سازگاری داشته باشد. بدین ترتیب امروزه اکثر وب‌سایت‌ها به صورت Responsive پیاده سازی می‌شوند تا صفحات وب در تمامی دستگاه‌هایی که امکان دسترسی به اینترنت و باز کردن مرورگر را دارند اعم از لپ‌تاپ، تبلت، موبایل، جلوه خوبی داشته باشند.

معمولا در تیم‌های برنامه نویسی روال کار به این صورت است که در ابتدا طراحی پروژه توسط تیم UI / UX انجام شده و سپس خروجی نهایی به توسعه دهنده جهت پیاده‌سازی پروژه داده می‌شود.

دوستان ما در تیم UI / UX، برای طراحی صفحات وب از ابزاری به نام Figma استفاده می کنند. Figma یک ابزار طراحی قدرتمند است که در مرورگر اجرا می‌شود و به شما در ایجاد وب‌سایت‌ها، لوگوها، آیکن‌ها کمک می‌کند.

تصویر زیر مربوط به طراحی صفحه لاگین در Figma در سه سایز Desktop, Tablet, Mobile می‌باشد.

<img src="images/img-1.png" />
  
همان‌طور که در تصویر می‌بینید، در سایز دسکتاپ، ما دو بخش را داریم که در قسمت سمت راست، فرم Login  قرار گرفته  است و در سمت چپ، لوگو محصول، و همچنین توضیح کوتاهی در مورد محصول قرار گرفته است. در سایز تبلت به دلیل کمبود فضا بخش اصلی که فرم Login است نگه داشته شده، همچنین لوگو مربوط به پروژه هم به قسمت بالای فرم Login و با رنگی متفاوت از لوگو در سایز دسکتاپ قرار گرفته است و در نهایت در سایز موبایل، به دلیل برابری تقریبی سایز صفحه نمایش موبایل با باکس سفید، باکس سفید هم حذف شده است.

شما در Figma  می‌توانید با کلیک بر روی هر المنت و یا کلیک بر روی لایه المنت مورد نظر، در سمت چپ صفحه، به مشخصات المنت، اعم از رنگ، سایز و موارد دیگر، در سمت راست صفحه دسترسی داشته باشید.
لازم به ذکر است بیشترین استفاده ما از این مشخصات مربوط به سایز المنت، رنگ، فونت و فاصله المنت مورد نظر از بقیه اجزای صفحه می‌باشد. لذا، لطفا از کپی کردن کدهای CSS موجود در Figma اجتناب کرده و فقط برای راهنمایی گرفتن و بالا بردن دقت در پیاده‌سازی طرح از این کدها استفاده کنید.
  
همچنین شما می توانید مطابق تصویر زیر از سمت چپ صفحه، تب Export ، آیکن‌ها، لوگو و تمامی تصاویر موجود در طرح مربوط به پروژه را با هر نام و فرمتی که می‌خواهید دانلود نمایید. 

  
<img src="images/img-2.png" />
 
در ادامه به منظور پیاده‌سازی طرح داخل Figma ، پروژه‌ای به نام  TaskManagement ایجاد می‌کنیم. پوشه‌هاُ فایل‌ها و کدهای اضافی را همانند جلسات گذشته حذف می‌کنیم.

از این جلسه به بعد می‌خواهیم از فریم ورک ‌Bit برای ایجاد سریع‌تر و آسان‌تر المنت‌ها استفاده کنیم. 


برای نصب این فریم‌ورک، همانند نصب Delegate.SassBuilder در جلسه گذشته از بخش Solution Explorer بر روی Dependencies کلیک راست کرده و از منوی باز شده گزینه Manage NuGet Packages را انتخاب و در تب ‌Browse در قسمت سرچ باکس bit.client.web.blazor را جستجو و نصب کنید.

سپس خط زیر را که مربوط به کدهای CSS این فریم ورک می‌باشد به تگ head  داخل فایل index.html در پوشه wwwroot اضافه می‌کنیم.
  
  <div dir="ltr">

  ```razor
    
    <link rel="stylesheet" href="_content/Bit.Client.Web.BlazorUI/styles/styles.min.css" asp-append-version="true" />
    
  ``` 
  </div>

و خط زیر را هم که مربوط به کدهای JavaScript این فریم ورک می‌باشد را به انتهای تگ body این فایل اضافه می‌کنیم.  
 
  <div dir="ltr">

  ```razor
    
    <script src="_content/Bit.Client.Web.BlazorUI/scripts/bit.client.web.js" asp-append-version="true"></script>
    
  ``` 
  </div>

کدهای داخل فایل index.html  بعد از افزودن دو خط بالا به صورت زیر می‌باشد.

 <div dir="ltr">

  ```razor
    
    <!DOCTYPE html>
    <html>

      <head>
          <meta charset="utf-8" />
          <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
          <title>TaskManagement</title>
          <base href="/" />
          <link rel="stylesheet" href="_content/Bit.Client.Web.BlazorUI/styles/styles.min.css" asp-append-version="true" />
          <link href="TaskManagement.styles.css" rel="stylesheet" />
      </head>

      <body>
          <div id="app">Loading...</div>

          <script src="_framework/blazor.webassembly.js"></script>
          <script src="_content/Bit.Client.Web.BlazorUI/scripts/bit.client.web.js" asp-append-version="true"></script>
      </body>

    </html>

  ``` 
  </div>

بعد از اتمام نصب برمی‌گردیم به ساختار پروژه، در پوشه pages  فایل جدیدی به نام Login.razor ایجاد کرده و کد زیر را به منظور ایجاد ساختار اصلی پروژه در این صفحه بنویسید. 

  
  
  <div dir="ltr">

  ```razor
    @page "/login"

    <div class="container">
        <div class="content">
            <div class="card product-description">
                <img src="images/logo-desktop.png" alt="Task Management" class="logo" />
                <p>
                    Task management is more than a to-do list.
                    It means tracking tasks from beginning to end, delegating subtasks to teammates,
                    and setting deadlines to make sure projects get done on time.
                </p>
            </div>
            <div class="card login-form">
                <h1>
                    Welcome back!
                </h1>

                <form>
                    <BitTextField Type="TextFieldType.Text" Placeholder="Username" Class="m-b-20"/>

                    <BitTextField Type="TextFieldType.Password" Placeholder="Password" Class="m-b-20"/>

                    <BitButton>
                        Sign in
                    </BitButton>
                </form>
            </div>
        </div>
    </div>

  ``` 
  </div>
  
  برای توضیح بهتر کد بالا، بگذارید از تصویر طرح صفحه Login، در سایز دسکتاپ، استفاده کنیم.

<img src="images/img-3.png" width="700px" />

تگ div  با کلاس container مربوط به پس زمینه رنگی می‌باشد که در پشت همه المنت‌های داخل صفحه قرار دارد.

از تگ div با  کلاس content ، توسط استایل‌هایی که به این کلاس در کدهای CSS اختصاص می‌دهیم برای نگه‌داشتن دو بخش فرم لاگین و توضیحات محصول کنارهم استفاده می‌کنیم.

از تگ div با دو کلاس card, product-description  برای ایجاد بخشی که به رنگ بنفش است استفاده کرده‌ایم.

داخل همین div از تگ img برای نمایش لوگو مربوط به سایز دسکتاپ استفاده کرده‌ایم. 

نکته: دقت کنید که همیشه ویژگی alt مربوط به تگ img را مقداردهی نمایید، چرا که اگر کاربر به دلایلی نتواند تصویر را مشاهده کند (به دلیل اتصال کند ، خطا در ویژگی src و … ) ، مقداری که به ویژگی alt اختصاص داده‌اید به جای آن تصویر نمایش داده می‌شود.

از تگ p در HTML  برای تعریف یک پاراگراف استفاده می‌کنیم. در این جا هم ما توضیحات مربوط به این پروژه را داخل این تگ قرار داده‌ایم.

از تگ div با کلاس card, login-form  برای ایجاد قسمت سفید رنگ مربوط به فرم لاگین استفاده می‌کنیم.

از تگ‌های h1 تا h6 برای تعریف عناوین در HTML استفاده می‌کنیم. تگ h1  مهمترین عنوان و تگ h6، عنوان با کمترین درجه اهمیت در صفحه را تعریف می‌کند.

تگ form،  یک فرم را در HTML  تعریف می‌کند. تگ form می‌تواند شامل تگ‌های input برای گرفتن اطلاعات از کاربر مانند Username, Password باشد که در نهایت کاربر را قادر می‌سازد اطلاعاتی را که از طریق این ورودی‌ها وارد کرده است را، به یک وب سرور ارسال کند. 
 
<img src="images/img-4.png"/>

</div>
