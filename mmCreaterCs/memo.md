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

# mmの仕様に関するメモ

各要素名は下記の様に取り扱う。

root: ルート。中央オブジェクト。
branch: 枝。各枝分かれの根幹。
branch-root: 枝の根本要素。
parent: ある要素の親要素。
child: ある要素の子要素。

## POSITION

branchの位置を設定する。

### 効果

POSITIONは、下記のように効果する。

設定Node | 効果
root要素 | 指定のない全branchの配置を右/左に振り分ける
branch-root | branchの配置を右/左に振り分ける
branchのchild | 効果なし

branch-root配下のchildにPOSITIONをセットした場合でも、branch-rootの位置に設置される。

ex: branch-rootがPOSITIONなしで右配置のとき、childのPOSITION=leftとしても、このbranchは右配置となる。

### 設定するNode

FreeMindで生成した場合、branch-rootにのみ設定される。

ただし、効果に記載があるように、rootに設定した場合は、表示に対して効力がある。
