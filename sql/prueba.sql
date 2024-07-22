create table public.Products
(
    name        varchar not null,
    description varchar not null,
    price       integer,
    id          integer not null
        constraint id
            primary key
);

alter table public.Products
    owner to postgres;

INSERT INTO public.Products (name, description, price, id) VALUES ('producto_1', 'producto_1', 1000, 1)

INSERT INTO public.Products (name, description, price, id) VALUES ('huevos', 'huevos', 11, 2)

INSERT INTO public.Products (name, description, price, id) VALUES ('pasta', 'cereal', 15, 3)