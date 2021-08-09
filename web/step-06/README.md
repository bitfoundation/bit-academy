<div dir="rtl">
  
## جلسه ششم- پیاده‌سازی TodoList	
  
در این جلسه می خواهیم به پیاده‌سازی یک TodoList ساده همانند تصویر زیر بپردازیم.

<img src="images/1-1.png" width="500px"/>

ابتدا در پوشه pages فایل جدیدی به نام TodoPage.razor ایجاد کرده و کد زیر را به منظور تعیین آدرس این صفحه در ابتدای این فایل قرار می دهیم.

<div dir="ltr">

```razor

  @page "/todo";

``` 
</div>

در ادامه فایلی با نام TodoItem.cs به ریشه پروژه اضافه کنید.  

<img src="images/2.png" width="500px"/>

در این فایل قرار است کلاسی به نام TodoItem داشته باشیم که این کلاس شامل فیلدهای مربوط به یک مورد todo می‌باشد. 

<div dir="ltr">

```c#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class TodoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsDone { get; set; }

        public bool IsEdit { get; set; } = false;
    }

``` 
</div>

همانطور که در کد بالا می بینید قرار است هر کدام از Todo ها، شامل چهار فیلد Id, Title, IsDone و IsEdit  با مقدار پیشفرض  false باشد.

سپس فایل جدیدی به نام TodoPage.razor.cs ایجاد می‌کنیم.

برای نگهداری Todo ها باید از یک لیست استفاده کنیم. یک لیست مجموعه‌ای از object های قابل دسترسی است که قابلیت جستجو، مرتب کردن و تغییر دادن اعضای داخل آن را برای ما فراهم می کند.

در این فایل، ابتدا یک متغیر به نام TodoList  ازنوع List برای todo item ها  به صورت زیر ایجاد می کنیم. در ادامه قرار است در فایل TodoPage.razor از این متغیر به منظور نگهداری وضعیت لیست todo ها استفاده کنیم.

<div dir="ltr">

```c#

using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Pages
{
    public partial class TodoPage
    {
        public List<TodoItem> TodoList = new();
    }
}

``` 
</div>

همان طور که در کد بالا می‌بینید با فراخوانی "List<TodoItem>" یک لیست از روی کلاس TodoItem که از قبل در فایل TodoItem.cs ایجاده کرده بود‌ه‌ایم، می‌سازیم.

به فایل TodoPage.razor  برمیگردیم.

 ما احتیاج به یک لیست برای نشان دادن todo ها داریم. بدین منظور از کامپوننت BitBasicList  کامپوننت های Bit به صورت زیر، استفاده می‌کنیم.

<div dir="ltr">

```razor
  <div class="container">
    
    <BitBasicList Items="" Virtualize="true" Class="todo-list">
        <RowTemplate Context="">
            <div Class="todo-item"></div>
       </RowTemplate>
    </BitBasicList>
    
  </div>

``` 
</div>

</div>
