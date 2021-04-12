# 給定固定浮點位數，補齊所有數字浮點數位數

- 前端以字串儲存浮點數補 0
  - 以 StringToNullableDecimalJsonConverter 處理 json 字串 與 C# decimal 互轉 !
- 後端以 decimal 儲存浮點數
- 資料庫以 varchar 儲存計算結果
  - 以 AnsiStringToNullDecimalHandler 處理 C# 字串 與 varchar 互轉 !

