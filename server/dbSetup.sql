CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE burgers (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    price DECIMAL(10, 2),
    img_url VARCHAR(255) NOT NULL
);

CREATE TABLE desserts (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    price DECIMAL(10, 2),
    img_url VARCHAR(255) NOT NULL
);

CREATE TABLE salads (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    price DECIMAL(10, 2),
    img_url VARCHAR(255) NOT NULL
);

DROP TABLE burgers

INSERT INTO
    burgers (name, price, img_url)
VALUES (
        'Spicy Chicken Burger',
        11.50,
        'https://placehold.co/400x300/DAF7A6/000000?text=Chicken+Burger'
    ),
    (
        'Veggie Delight Burger',
        10.00,
        'https://placehold.co/400x300/33FF57/000000?text=Veggie+Burger'
    );

INSERT INTO
    salads (name, price, img_url)
VALUES (
        'Caesar Salad',
        8.75,
        'https://placehold.co/400x300/3366FF/FFFFFF?text=Caesar+Salad'
    ),
    (
        'Mediterranean Quinoa Salad',
        9.50,
        'https://placehold.co/400x300/FFC300/000000?text=Quinoa+Salad'
    ),
    (
        'Garden Fresh Salad',
        7.25,
        'https://placehold.co/400x300/C70039/FFFFFF?text=Garden+Salad'
    );

INSERT INTO
    desserts (name, price, img_url)
VALUES (
        'Chocolate Lava Cake',
        6.99,
        'https://placehold.co/400x300/900C3F/FFFFFF?text=Lava+Cake'
    ),
    (
        'New York Cheesecake',
        7.50,
        'https://placehold.co/400x300/581845/FFFFFF?text=Cheesecake'
    ),
    (
        'Apple Crumble',
        6.00,
        'https://placehold.co/400x300/FF5733/000000?text=Apple+Crumble'
    );