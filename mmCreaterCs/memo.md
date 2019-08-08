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


