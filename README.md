1.Các nuget package cần sử dụng:

  -Mở tool -> nuget package manager -> package manager console

  -Các thứ cần cài (copy các câu này vào console đế tiến hành install)

  -Install-Package Microsoft.EntityFrameworkCore (Cài cho DAL, BLL, common và web)

  -Install-Package Microsoft.EntityFrameworkCore.SqlServer (Cài cho DAL,BLL và web)

  -Install-Package Microsoft.EntityFrameworkCore.Tools (Cài cho DAL,BLL và web)

  -Lưu ý: Khi cài cho mỗi project phải set as startup project và dưới bảng console phải CHỈNH DEFAULT PROJECT THEO MỖI PROJECT TƯƠNG ỨNG.

  -Liên kết các project: Dependencies -> right click -> add reference -> project

  -Reference ở BLL -> chọn project là DAL với common

  -Reference ở DAL -> chọn project là common

  -Reference ở Web -> chọn hết project

  => Khi đó các project sẽ liên kết với nhau tạo nên solution



2.Tạo cơ sở dữ liệu bằng Migration

  -Sử dụng migration (Tools -> Nuget Package Manager -> Package Manager Console)
  
  -Chuyển Default project sang ShoesShopWebApp.DAL
  
  -Bước 1: Tạo mới migration: add-migration ShoesShopDB
  
  -Bước 2: Chuyển dữ liệu qua database: update-database –verbose
