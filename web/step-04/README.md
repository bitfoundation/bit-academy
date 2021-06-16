<div dir="rtl">
  
## جلسه چهارم - پیاده سازی ماشین حساب در Blazor
  
در این جلسه قصد داریم یک ماشین حساب ساده مطابق تصویر زیر با استفاده از Blazor پیاده سازی کنیم.

<img width="400px" src="images/img-1.png" />

همانند جلسه گذشته پروژه جدیدی به نام SimpleBlazorCalculator ایجاد می‌کنیم و مجددا فایل‌ها و پوشه‌های اضافی را مطابق جلسه گذشته حذف می‌کنیم. با این تفاوت که هر سه فایل موجود در پوشه Pages را حذف کنید. 
داخل پوشه Pages  فایل جدید به نام Calculator.razor  ایجاد می‌کنیم.
دقت کنید که در تعیین نام کامپوننت حرف اول باید بزرگ باشد.
وارد فایل Calculator.razor شده و در ابتدای این فایل کد زیر را برای تعیین مسیر این صفحه در مرورگر وارد کنید.

<div dir="ltr">

  ```razor
  
  @page "/calculator"
  
  ```
</div>

<img width="300px" src="images/img-2.png" />

 برای ایجاد ساختار اولیه ماشین حساب کد زیر را در فایل Calculator.razor  وارد کنید.

<div dir="ltr">

  ```html
  
    <div>
      <div>
          <div>
              <input type="text"/>
          </div>
          <div>
              <input type="text"/>
          </div>
          <div>
              <button>+</button>
              <button >-</button>
              <button>*</button>
              <button>/</button>
          </div>
          <div>
              <input type="text" readonly/>
          </div>
      </div>
  </div>
  
  ```
</div>


از تگ های Input برای ایجاد کنترل‌های تعاملی برای فرم‌های تحت وب به منظور پذیرش داده‌ها از کاربر استفاده می‌شود. به دلیل گستردگی در انواع داده‌ها، انواع متفاوتی از تگ‌های input را داریم که نوع آنها را با استفاده ویژگی type این تگ، مانند موارد زیر مشخص می‌کنیم.


<div dir="ltr">

  ```html
  
  <input type="number">
  <input type="password">
  <input type="tel">
  <input type="text">(default value)
  <input type="url">
  
  ```
</div>

در این تمرین همانطور که مشاهده می‌کنید ازدو تگ input برای گرفتن دو عدد از کاربر استفاده می‌کنیم.
و همچنین از یک تگ input با ویژگی readonly به معنای این که محتوای این تگ قابل تغییر نیست و فقط قابل خواندن است، برای نتیجه نهایی استفاده می‌کنیم.

  
<img width="300px" src="images/img-3.png" />

به منظور افزودن استایل به المنت در این جلسه، از نام class هر المنت، به عنوان selector استفاده می‌کنیم. در نتیجه کدهای مربوط به فایل Calculator.razor به صورت زیر تغییر می کنند.

<div dir="ltr">

  ```html
  
    <div class="container">
    <div class="card">
        <div class="field">
            <input placeholder="0"/>
        </div>
        <div class="field">
            <input placeholder="0"/>
        </div>
        <div class="action">
            <button class="btn">+</button>
            <button class="btn">-</button>
            <button class="btn">*</button>
            <button class="btn">/</button>
        </div>
        <div class="field result">
            <input readonly placeholder="0"/>
        </div>
    </div>
</div>
  
  ```
</div>

همان طور که در کد بالا می‌بینید (class="field result") می‌توانیم مقادیر متعددی را برای ویژگی class هر المنت در نظر بگیریم. 
  
تفاوت استفاده از نام class به جای نام id در این است که اگر برای یک المنت id تعیین کنیم، از نام id آن المنت نمی‌توانیم برای المنت‌های دیگر استفاده کنیم. ولی همان طور که در کد بالا می‌بینید زمانی که از نام class برای انتخاب یک المنت استفاده می‌کنیم می توانیم از همان نام، برای المنت‌های دیگرهم، که می‌خواهیم همان پراپرتی‌ها را داشته باشند، استفاده کنیم.
زمانی که می‌خواهیم از نام class به عنوان selector استفاده کنیم، قبل از نام کلاس باید " . " اضافه کنیم.
با استفاده از کدهای زیر استایل مورد نظر ما ایجاد می‌شود.

<div dir="ltr">

  ```css
 .card {
    margin: 120px auto;
    padding: 20px;
    width: 400px;
    height: 400px;
    background-color: cornflowerblue;
    border-radius: 5px;
    box-shadow: 1px 2px 10px 0 rgba(0, 0, 0, 0.3);
}
 
.field {
    margin: 15px
}
 
input {
    padding: 10px;
    width: 350px;
    height: 30px;
    color: cornflowerblue;
    border: 2px solid #dcdcdc;
    text-align: center;
    font-size: 30px;
}
 
.field.result {
    margin-top: 75px;
}
 
.action {
    margin: 30px 0;
    text-align: center;
}
 
.btn {
    margin: 5px;
    width: 80px;
    height: 80px;
    border-radius: 5px;
    border: 2px solid #dcdcdc;
    line-height: 80px;
    color: cornflowerblue;
    font-size: 35px;
    cursor: pointer;
}
  
  ```
</div>

<img width="400px" src="images/img-4.png" />
  
<div dir="ltr">

  ```c#
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace SimpleBlazorCalculator.Pages
{
    public partial class Calculator
    {
        string num1;
        string num2;
        string finalresult;
 
        void AddNumbers()
        {
            finalresult = (Convert.ToDouble(num1) + Convert.ToDouble(num2)).ToString();
        }
 
        void SubtractNumbers()
        {
            finalresult = (Convert.ToDouble(num1) - Convert.ToDouble(num2)).ToString();
        }
 
        void MultiplyNumbers()
        {
            finalresult = (Convert.ToDouble(num1) * Convert.ToDouble(num2)).ToString();
        }
 
 
 
        void DivideNumbers()
        {
            if (Convert.ToDouble(num2) != 0)
            {
                finalresult = (Convert.ToDouble(num1) / Convert.ToDouble(num2)).ToString();
            }
 
            else
            {
 
                finalresult = "Cannot Divide by Zero";
            }
        }
    }
}

  
  ```
</div>
  
</div>
