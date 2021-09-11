<div dir="rtl">

  ## جلسه دوم- پیاده سازی شمارنده با استفاده از HTML, CSS, JavaScript
  
  در این جلسه قصد داریم شمارنده ای مشابه تصویر زیر پیاده سازی کنیم. هدف ما در این جلسه این است که با انجام یک تمرین ساده شما را با کاربرد  HTML, CSS, JavaScript در صفحات وب آشنا کنیم.

<img width="400px" src="images/img-1.png" />

## لیست موضوعات	
1. [ایجاد پروژه در Visual Studio](#CreateProject)	
2. [ایجاد ساختار اصلی با HTML](#CreateMainStructure)	
3. [افزودن استایل با استفاده از CSS](#AddStyle)	
4. [افزودن رفتار تعاملی با استفاده از JavaScript](#AddFunctionality)	
	
	
## ایجاد پروژه در Visual Studio <a name="CreateProject"></a>  
	
  در ابتدا پوشه ای (یا همان فولدر) به نام  SimpleCounter  در مسیر دلخواه ایجاد می‌کنیم. از همین ابتدا به اسامی دقت کنید، بزرگ و کوچکی حروف، داشتن یا نداشتن Space و... تاثیرگذار است.

سپس وارد Visual Studio  شده و از قسمت   Get Started  مطابق تصویر زیر روی  گزینه  Open a local folder  کلیک کرده و فولدر مورد نظر را انتخاب می کنیم.

  
<img width="500px" src="images/img-2.png" />
 
   مطابق تصویر زیر بعد از وارد شدن به محیط اصلی Visual Studio  در قسمت  Solution Explorer  روی اسم فولدر کلیک راست  و روی گزینه Add کلیک کرده  و در ادامه گزینه NewFile را انتخاب می‌کنیم تا یک فایل جدید ایجاد شود سپس نام فایل را به counter.html تغییر می دهیم.

<img width="500px" src="images/img-3.png" />

## ایجاد ساختار اصلی با HTML <a name="CreateMainStructure"></a>	
	
  فایل های HTML معمولا با پسوند html و یا htm مشخص می شوند. با استفاده از کدهای HTML ساختار اصلی صفحات وب را ایجاد می‌کنیم. صفحات HTML شامل انواع element ها یا عناصر هستند به عنوان مثال یک صفحه HTML می تواند شامل element های text, image, table و…. باشد.
هر عنصر HTML توسط یک تگ شروع و یک تگ پایان به صورت زیر تعریف می شود.

  <div dir="ltr">

  ```html
   
   <tagname> Element content </tagname>
   
  ```
  </div>
  
  با استفاده از کدهای HTML  زیر، ساختار شمارنده را ایجاد می‌کنیم. در ادامه به توضیح کوتاهی از هر کدام از تگ های زیر می پردازیم.
  
  <div dir="ltr">

  ```html
   
   <html>
     <head>
        <title>
          Counter
        </title>
     </head>
     
     <body>
      <div>
        <div>
          <span>0</span>
        </div>
        <div>
          <button>Increase</button>
          <button>Decrease</button>
        </div>
      </div>
     </body>
  </html>
   
  ```
  </div>
  
  تگ html عنصر اصلی یک صفحه HTML است و مشخص کننده شروع و پایان یک فایل HTML  می باشد.
  
 تگ head می تواند شامل تگ title برای مشخص کردن عنوان صفحه، یا تگ های link و یا تگ‌های meta و … باشد.
  
  تگ body تمامی مواردی که جنبه نمایش دارند و قرار است به کاربر نشان داده شوند داخل این تگ تعریف می‌شوند.
  
  تگ div (مخفف divisions) برای بخش بندی قسمت‌های مختلف صفحه و یا گروه بندی عناصر استفاده می‌شود.
  
  تگ span معمولا برای مشخص کردن قسمتی از متن استفاده می‌شود.
  
  تگ button  برای ایجاد دکمه ای که قابلیت کلیک شدن داشته باشه استفاده می‌شود.
  
  به منظور دیدن خروجی کدها با استفاده از Ctrl+S  تغییرات را ذخیره و در پوشه محل قرارگیری فایل html، روی آن دو بار کلیک کنید تا در مرورگر باز شود.
   
  از این پس هر تغییری که در فایل ها ایجاد کردید ابتدا تغییرات را ذخیره و سپس برا دیدن نتیجه تغییرات، صفحه مرورگر را refresh نمایید.
 
 	
## افزودن استایل با استفاده از CSS <a name="AddStyle"></a>
فایل‌های CSS با پسوند CSS مشخص می‌شوند. با استفاده از کدهای CSS، نحوه نمایش عناصر HTML  را بر روی صفحه تعیین می‌کنیم.
برای افزودن کدهای CSS به این تمرین ابتدا فایل جدیدی به نام counter.css ایجاد می‌کنیم.
	
و سپس فایل counter.css  رو با استفاده از تگ link داخل تگ head و با استفاده از ویژگی href این تگ، به فایل counter.html اضافه کنیم.
	

<div dir="ltr">

  ```html
  
  <head>
    <title>
      Counter
    </title>
    <link rel="stylesheet" href="counter.css"/>   
  </head>
    
  ```

</div>
	
الگوی کلی دستورات  CSS  به صورت زیر می‌باشد.

<img width="400px" src="images/css-declaration-1.png" />
	
		
همانطور که مشاهده می‌کنید دستورات CSS از سه بخش Selector، Property، Property value  تشکیل شده است.

Selector: به منظور اضافه نمودن استایل به یک element باید آن element را انتخاب کنیم. یکی از روش های انتخاب element در CSS، استفاده از نام خود element می‌باشد.  برای مثال در تصویر بالا ما از نام تگ button به عنوان سلکتور استفاده کرده‌ایم،  به  این معنا که می‌خواهیم استایلی را برای تمامی  button  های موجود در صفحه تعیین کنیم. 

 Property: با استفاده از Property ها، ویژگی‌های نمایش یک element در HTML  را تعیین می‌کنیم. به عنوان مثال اگر بنویسیم background-color: red به این معناست که رنگ پس زمینه تمامی button های موجود در صفحه قرمز باشد.

Property value: برای هر Property یا ویژگی در CSS باید یک مقدار در نظر گرفته شود. به عنوان مثال در این تصویر، رنگ قرمز را برای پراپرتی background-color element یا تگ button در نظر گرفتیم.

برای نوشتن کدهای CSS  وارد فایل counter.css می‌شویم.
	
در ابتدا برای تعیین رنگ پس زمینه صفحه به صورت زیر عمل می‌کنیم.
	
<div dir="ltr">

```css

body {
  background-color: #fafafa;
}

```

</div>

در ادامه برای افزودن استایل به element‌های دیگر می خواهیم از روش انتخاب element با استفاده از ویژگی class هر element استفاده کنیم. بدین ترتیب به فایل counter.html رفته و برای هر کدام از element ها، ویژگی class  را با مقدار دلخواه تعیین می کنیم.


<div dir="ltr">

  ```html
  
  <body>
    <div class="card">
      <div class="counter">
        <span>0</span>
      </div>
      <div class="action">
        <button class="increase">Increase</button>
        <button class="decrease">Decrease</button>
      </div>
    </div>
  </body>
    
  ```

</div>
	
اگر ما همچنان از نام خود element برای انتخاب element استفاده می‌کردیم، پراپرتی‌هایی که به آن element اختصاص می‌دادیم تمامی element‌ها با آن نام را در صفحه تحت تاثیر قرار می‌داد. به عنوان مثال در این تمرین ما دو دکمه داریم که یکسری از ویژگی‌‌های ظاهری بین آنها مشترک هستند مانند اندازه دکمه‌ها که ما می توانیم همچنان از نام خود element (button) برای انتخاب element استفاده کنیم اما یک سری از ویژگی‌ها مانند رنگ پس‌زمینه هر دکمه با دکمه بعدی متفاوت می‌باشد که در اینجا باید از یک Selector یا انتخاب‌گر دیگر مانند class برای انتخاب element مورد نظر استفاده کنیم.

برای انتخاب element با استفاده از نام class از " . "  قبل از نوشتن نام selector استفاده می‌کنیم.

<div dir="ltr">

```css

.card {
  Padding: 20px;  /* .برای تعیین  فاصله المنت از محتوای درون المنت استفاده می‌شود */
  Margin: 200px auto; /* .برای تعیین فاصله المنت از محتوای بیرون از المنت استفاده می‌شود */ 
  Width: 400px;  /* .برای تعیین عرض المنت استفاده می‌شود */
  Height: 400px;  /* .برای تعین ارتفاع المنت استفاده می‌شود */
  Background-color: lightskyblue;  /* .برای تعیین رنگ پس زمینه المنت استفاده می‌شود */
  Box-shadow: 1px 2px 10px 0 #808080;  /* .برای افزودن سایه به المنت مورد نظر استفاده می‌شود */
  Border-radius: 5px;  /* .باافزودن شعاع به گوشه‌های یک المنت که در نهایت موجب خمیدگی آن گوشه می‌شود */
}


```

</div>

به علت کامنت‌های فارسی داخل این CSS Style، ممکن است موقع ذخیره سازی، با دیالوگ زیر مواجه شوید که گزینه Yes را انتخاب کنید.

<img width="500px" src="images/img-4.png" />

هر کدام از پراپرتی‌های padding و margin حداکثر چهار عدد را می‌توانند به عنوان مقدار بگیرند که این چهار عدد به ترتیب نشان دهنده فاصله از بالا، راست، پایین و چپ می‌باشند. اگر فقط یک مقدار به هر کدام از این property ها اختصاص دهیم به این معنی است که هر چهار طرف فاصله‌ای یکسان را نسبت به محتوای بیرون از element و یا محتوای درون element را دارند و اگر دو مقدار اختصاص دهیم به این معنی است که عدد اول مربوط به فاصله از بالا و پایین element، و عدد دوم مربوط به فاصله از چپ و راست element می‌باشد.
اختصاص دادن مقدار auto  به جای عدد دوم به پراپرتی  margin  به این معنی است که element ما از سمت چپ و راست در قسمت وسط قرار می‌گیرد.

<img width="400px" src="images/img-9.png" />		

<div dir="ltr">

```css

.counter {
  margin: 50px auto; 
  width: 150px;
  height: 150px;
  line-height: 150px; /* .متن داخل المنت به اندازه مقداری که داده شده از خط قبل و بعد فاصله می‌گیرد */
  background-color: #eee;
  border-radius: 50%;  /* .با دادن این مقدار به این پراپرتی المنت دایره‌ای شکل می‌شود */
  border: 10px solid #2196f3; /* .استایل، عرض و رنگ حاشیه المنت را مشخص می‌کند  */
  text-align: center;  /* .نحوه چیدمان متن داخل المنت را مشخص می‌کند */
  font-size: 60px;  /* .سایز فونت متن داخل المنت را مشخص می‌کند */
  Font-weight: bold;  /* .ضخامت متن داخل المنت را مشخص می‌کند */
  color: #107732;  /* .رنگ متن داخل المنت را مشخص می‌کند */
}


```

</div>
	
<img width="400px" src="images/img-10.png" />	
	
<div dir="ltr">

```css

.action {
  text-align: center; 
}


```

</div>	
	
<img width="400px" src="images/img-11.png" />		

	
<div dir="ltr">

```css

button {
  padding: 20px 30px;
  margin: 5px;
  font-size: 24px;
  font-weight: bold;
  border-radius: 5px;
  cursor: pointer; /* .زمانی که با موس روی دکمه‌ها می‌رویم اشاره گر ماوس به شکل دست در می‌یاید */
  color: white;  
}

.increase {
  background-color: #18cd73;
  border: 3px solid #19a35d;
}

.decrease {
  background-color: #ef7694;
  border: 3px solid #b74b66;
}

```

</div>	
	
<img width="400px" src="images/img-12.png" />	

	
## افزودن رفتار تعاملی با استفاده از JavaScript <a name="AddFunctionality"></a>		
	
به منظور این که به صفحات وب عملکردی را اضافه کنیم، مثلا در این تمرین، زمانی که روی دکمه increase  کلیک کردیم یه واحد به عدد اضافه و زمانی که روی دکمه decrease کلیک کردیم یک واحد از عدد کم شود، از کدهای JavaScript استفاده می‌کنیم. 
بدین ترتیب فایل جدیدی به نام  counter.js ایجاد می‌کنیم.
در ادامه ابتدا باید فایل  counter.js را به فایل counter.html اضافه کنیم. به فایل counter.html رفته و در انتهای تگ body یک تگ script اضافه می کنیم. با استفاده از ویژگی src این تگ آدرس فایل  counter.js  را مشخص می‌کنیم.

قبل از ورود به فایل counter.js در همین فایل counter.html برای عنصری که می‌خواهیم محتوای درونش با هر کلیک کاربر،  بر روی دکمه‌ها آپدیت شود، یک شناسه منحصر به فرد یا همان ویژگی id را  به صورت کد زیر تعیین می‌کنیم.


<div dir="ltr">

  ```html

<div class="counter">
	<span id="count">0</span>
</div> 
	
  ```

</div>


ویژگی id،  یک شناسه را برای یک element مشخص می کند. مقداری که به ویژگی  id اختصاص می‌دهیم باید در فایل HTML منحصر به فرد باشد.

از ویژگی id بیشتر برای تغییر دادن element ‌ها و یا محتوای داخل element ‌ها توسط JavaScript در زمان اجرا استفاده می‌کنیم.


<div dir="ltr">

  ```html
  
    <body>
        <div class="card">
            <div class="counter">
                <span id="count">0</span>
            </div>
            <div class="action">
                <button class="increase" onclick="increase()">
                    Increase
                </button>
                <button class="decrease" onclick="decrease()">
                    Deacrease
                </button>
            </div>
        </div>
        <script src="counter.js"></script>
    </body>
    
  ```

</div>

برای نوشتن کدهای Javascript به فایل counter.js  رفته و در ابتدا یک متغیر به نام counter  به صورت زیر تعریف می‌کنیم.

<div dir="ltr">

  ```js
  
  let counter = document.getElementById("count");
    
  ```

</div>


در کد بالا let یک کلمه کلیدی برای تعریف کردن متغیر در Javascript می‌باشد. هر متغیر می‌تواند حاوی هر مقداری باشد. در اینجا قصد ما داشتن متغیری است که به element با id  و یا شناسه count اشاره می‌کند. با استفاده از متد getElementById بر روی document یا سند(فایل) HTML می‌توانیم به element با id  و یا شناسه‌ای که به این متد پاس می‌دهیم دسترسی داشته باشیم.


نکته: هر متد (یا function)، یک بلاک کد از پیش تعریف شده است که به منظور انجام وظیفه ای خاص مانند تبدیل یک مقدار به یک رشته و یا انتخاب یک element و … تعیین شده است.
	

 صفحه مرورگر را refresh کرده و روی صفحه کلیک راست و گزینه‌ی inspect  را انتخاب کنید. محیطی که با انتخاب این گزینه برای شما باز می‌شود محیط developer tools  نام دارد. سپس وارد تب console  شوید. در تب console می‌توانید دستوراتی را نوشته و خروجی آنها را ببینید. برای مثال با نوشتن 2 + 2 و زدن دکمه Enter، می‌توانید جواب را که برابر 4 هست ببینید.
به علاوه، خطاهایی که ممکن است در هنگام کار با برنامه رخ دهند را نیز در اینجا می‌توانید مشاهده کنید.
	
<img width="500px" src="images/img-7.png" />
	
صفحه مرورگر خود را در همین حالت نگه داشته و مجددا به فایل counter.js  رفته و خط زیر را به این فایل اضافه نمایید.
	

<div dir="ltr">

  ```js
  
  console.log (counter);
    
  ```

</div>

مجددا صفحه مرورگر را refresh نمایید همان طور که می‌بینید مقداری که داخل متغیر  counter قرار گرفته در قسمت console چاپ شده است.

<img width="500px" src="images/img-8.png" />
	 

از (console.log (counter  صرفا برای متوجه شدن مقدار داخل متغیر  counter استفاده کردیم و در ادامه کار احتیاجی به آن نداریم بنابراین این خط از کد را پاک می‌کنیم.

در ادامه باید دو تابع یا function  برای اضافه کردن و کم کردن از عدد بنویسیم.

<div dir="ltr">

  ```js
  
  function increase() {
	  counter.textContent++ ; 
  }
    
  ```

</div>

از متد  textContent  برای دسترسی به عدد داخل element استفاده می‌کنیم. با استفاده از عملگر " ++ " یک واحد به این عدد افزوده و با استفاده از عملگر " -- " یک واحد از این عدد کم می‌کنیم.

<div dir="ltr">

  ```js
  
  function decrease() {
	  counter.textContent-- ;
  }
  
  ```

</div>

در نهایت هر function باید یک جایی فراخوانی شود در این تمرین ما در نظر داشتیم با کلیک بر روی هر دکمه (افزایش یا کاهش عدد) انجام شود برای این منظور به فایل  counter.html  برمی گردیم و روی رویداد onclick هر کدام از button ها function مربوطه را به صورت زیر فراخوانی می‌کنیم.

<div dir="ltr">

  ```html
  
  <div class="action">
    <button class="increase" onclick="increase()">Increase</button>
    <button class="decrease" onclick="decrease()">Decrease</button>
  </div>
    
  ```

</div>
	
تغییرات را ذخیره و به مرورگر برمی‌گردیم. خروجی نهایی به صورت زیر می‌باشد.
	
<img width="400px" src="images/counter.gif" />

</div>


