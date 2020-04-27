SELECT products.name, categories.name FROM products LEFT JOIN category_product ON products.id = category_product.product_id LEFT JOIN categories ON categories.id = category_product.category_id
