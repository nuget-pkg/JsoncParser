#! /usr/bin/env bash
set -uvx
set -e
cd "$(dirname "$0")"
cwd=`pwd`
ts=`date "+%Y.%m%d.%H%M.%S"`
version="${ts}"

cd $cwd/JsoncParser
rm -rf Parser

cd $cwd/JsoncParser
rm -rf Parser/StrictJson
mkdir -p Parser/StrictJson
java -cp aparse-2.5.jar com.parse2.aparse.Parser \
  -language cs \
  -destdir Parser/StrictJson \
  -namespace Global.Parser.StrictJson \
  json.abnf
cd Parser/StrictJson
ls *.cs | xargs -i sed -i "1,9d" {}
mv Parser.cs Parser.cs.txt

cd $cwd/JsoncParser
rm -rf Parser/JsonC
mkdir -p Parser/JsonC
java -cp aparse-2.5.jar com.parse2.aparse.Parser \
  -language cs \
  -destdir Parser/JsonC \
  -namespace Global.Parser.JsonC \
  jsonc.abnf
cd Parser/JsonC
ls *.cs | xargs -i sed -i "1,9d" {}
mv Parser.cs Parser.cs.txt

#cd $cwd/JsoncParser
#rm -rf Parser/ELang
#mkdir -p Parser/ELang	
#java -cp aparse-2.5.jar com.parse2.aparse.Parser \
#  -language cs \
#  -destdir Parser/ELang \
#  -namespace Global.Parser.ELang \
#  elang.abnf
#cd Parser/ELang
#ls *.cs | xargs -i sed -i "1,9d" {}
#mv Parser.cs Parser.cs.txt
