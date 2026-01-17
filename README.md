Install Visual Studio Community free Version.

After Installation ,open Visual studio then click on file->New->project/Solution .

Then choose  "Console App (.Net Framework) " template , after that click on next.

Then open a window about Configure Project

    -Type Project Name as ProductSales
    
    -click on check box ax "place solution and project in the same Directory"
    
    - choose version .Net FrameWork 4.8

After that opens Program.cs class , copy the code from  https://github.com/TEswarreddy/ProductSales/blob/main/ProductSales/Program.cs and then paste on your class.

Right click on ProductSales File and then Click on add-> New Folder

    -> create DataLayer Folder 
       then right click on folder add below Items
          -  Counter.txt file
          -  AvailableProducts.json file
    ->Create ProductObjects Folder and then create a class Product.cs by right click on folder then add->AddItem->class type name as Product.cs
    

Open Product.cs class and then copy code from https://github.com/TEswarreddy/ProductSales/blob/main/ProductSales/ProductObjects/Product.cs and paste on your class


creating ExceptionLayer Dll fille and using in project

-Right Click on ProductSales/solution file on click on newproject then choose "Class library (.Net Framework)" template
-View the ExceptionLayer from https://github.com/TEswarreddy/ProductSales/tree/main/ProductSales
-create userdefined Exception classes as it as like ExceptionLayer folder
-Then click Build option, after it creates Dll file
-after that go to tha ProductSales -> References right clock on Reference then choose AddRefernece->Project click on checkBox of Exceptionlaye then click on Ok.

For Json Serilization and Deserialization install Newtonsoft package from NuGet Package

-right click on References then click on Manage Nuget Packages 
-then choose browse package then search "Newtonsoft" then click on install then it can be directly installed and saved to in your References.

Finally click on Run Option in visual Studio.......


??why you use or maintain layers like DataLayer and Exception Layer...??

  for reducing complexity in complex projects and finding,searching relevent code or solving bugs easily..
  if we maintainevery project  like 
  
                - DataLayer
                - Exceptionlayer
                - Business Logic Layer
                - UI layer
                
                it can be easy to maintain the projects, and we can do more complex project easy ..

??Why Exceptionlaye will be created Dll file ??

 we create Dll file means packagse we can use other project easily by adding refersences, it can be reduce the Duplication of userdefined Exceptions.
 in real World Project everything we build in dll file only.
                
                






    
