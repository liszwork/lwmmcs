## 方針

Nodeは自らの子要素をchild(List)にて、子要素となるNodeを蓄える。
ここでいう子要素は下記のようなマップのrootの場合、item1, item2を指す

root-+-item1
     |   +- item1-1
	 +-item2

## Common

### ロガーの導入

ひとまず単純なConsole.WriteLine()を使用している為、出力の分別がない。
下記が行えるようにする。

- 標準出力
- ファイル出力
- ログレベルによる制御

## Node.cs


## その他

VisualStudio - GitHub連携
https://opcdiary.net/visual-studio-2017%E3%81%A7git%E3%83%AA%E3%83%A2%E3%83%BC%E3%83%88%E3%83%AA%E3%83%9D%E3%82%B8%E3%83%88%E3%83%AA%E3%81%AE%E7%99%BB%E9%8C%B2%E3%81%A8push%E3%81%BE%E3%81%A7%E3%81%AE%E6%B5%81%E3%82%8C/
