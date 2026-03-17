#! /usr/bin/env clojure.exe
(ns my-app.core
  (:require ["child_process" :as cp]))

;; 非同期でコマンドを実行
(let [proc (cp/spawn "ls" #js ["-lh" "/usr"])]

  ;; 標準出力を受け取る
  (.. proc -stdout (on "data" (fn [data]
                                (js/console.log (str "stdout: " data)))))

  ;; 標準エラーを受け取る
  (.. proc -stderr (on "data" (fn [data]
                                (js/console.log (str "stderr: " data)))))

  ;; プロセス終了時の処理
  (.. proc (on "close" (fn [code]
                         (js/console.log (str "child process exited with code " code))))))
