#! /usr/bin/env clojure.exe
(def x 5)
(def v [:a :b])

;; Using syntax-quote and unquote
`(foo ~x bar)
;; => (user/foo 5 user/bar)  ; Note the symbol qualification

;; Using unquote-splicing in a vector
`(my-vec [~@v "c"])
;; => (user/my-vec [:a :b "c"])

;; Using unquote-splicing in a list
`(my-func ~@v)
;; => (user/my-func :a :b)
