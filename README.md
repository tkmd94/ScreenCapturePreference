# ScreenCapturePreference

VARIAN社製治療計画装置Eclipse上でスクリーンキャプチャを行うスクリプト「ScreenCapture」の設定変更を行うスクリプトです。  

[![LicenseBadges](https://badges.frapsoft.com/os/mit/mit.svg?v=102)](https://github.com/ellerbrock/open-source-badge/)  

## 導入方法

本スクリプトはbinary-plugin型となるため、事前にビルドして実行ファイルを生成する必要があります。  
ビルドで生成された「ScreenCapturePreference.esapi.dll」をEclipse上で実行します。  

動作検証：Eclipse version 15.6  

## 操作方法

- 「Tools」-->「Scripts」から「ScreenCapturePreference.esapi.dll」を選択します。
- 「Run」ボタンを押して実行します。
- 「Set folder」ボタンでキャプチャ画像の保存先を指定します。
- ラジオボタン「Full Screen」もしくは「Active Window」を選択してキャプチャ領域を設定します。
- 「Save Preference」ボタンを押して設定を保存します。
- 必要に応じて「Open folder」ボタンを押して指定フォルダを開きます。
## 各種設定
- 設定はユーザー毎かつ端末共通です。
- ユーザー毎の設定ファイルは次のフォルダに格納されています。
 - 「\\\ARIASVR\MLC\--- ESAPI ---\ScreenCapturePreference」
 - ファイル名は「ユーザー名」+「_ScreenCapturePreference.txt」
 - 「保存場所」と「キャプチャ領域」をカンマ区切りで指定します。
   - 保存場所：絶対パス指定　
   - キャプチャ領域：「FullScreen」もしくは「ActiveWindow」 
  
 例）「C:\Users\vms\Desktop,ActiveWindow」

## UI画面

![Screen capture of planCompare UI](https://github.com/tkmd94/ScreenCapturePreference/blob/master/SC.jpg)
