PGDMP     2    .                x            TravelCompany    12.2    12.2 m    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    17848    TravelCompany    DATABASE     �   CREATE DATABASE "TravelCompany" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Russian_Russia.1251' LC_CTYPE = 'Russian_Russia.1251';
    DROP DATABASE "TravelCompany";
                postgres    false            �            1255    17895    count1(integer)    FUNCTION     �   CREATE FUNCTION public.count1(counter integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
BEGIN
perform Countt(counter, 1);
return 0;
END
$$;
 .   DROP FUNCTION public.count1(counter integer);
       public          postgres    false            �            1255    17896    count2(integer)    FUNCTION     �   CREATE FUNCTION public.count2(counter integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
BEGIN
perform Countt(counter, -1);
return 0;
END
$$;
 .   DROP FUNCTION public.count2(counter integer);
       public          postgres    false            �            1255    17894    countt(integer, bigint)    FUNCTION       CREATE FUNCTION public.countt(count integer, val bigint) RETURNS void
    LANGUAGE plpgsql
    AS $$
DECLARE
BEGIN
FOR counter in 1..count loop
update "TravelCompany".test_table set first = first+val, second = second + val, three = three+val;
end loop;
END
$$;
 8   DROP FUNCTION public.countt(count integer, val bigint);
       public          postgres    false            �            1255    18370    generate_clients(integer)    FUNCTION     -  CREATE FUNCTION public.generate_clients(count_int integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
DECLARE
sur text;
name_cus text;
patr text;
addr text;
tel text;
BEGIN
FOR counter in 1..count_int loop
select generate_ru_str(15) into sur;
select generate_ru_str(8) into name_cus;
select generate_ru_str(9) into patr;
select generate_ru_str(25) into addr;
select generate_num(10) into tel;
insert into "TravelCompany".client(id_customer, surname, name, patronymic, address, telephone)
values (counter, sur, name_cus, patr, addr, tel);
end loop;
END
$$;
 :   DROP FUNCTION public.generate_clients(count_int integer);
       public          postgres    false            �            1255    18354    generate_date()    FUNCTION     �   CREATE FUNCTION public.generate_date() RETURNS date
    LANGUAGE plpgsql
    AS $$
DECLARE
date_pr date;
BEGIN
select  to_timestamp(1388534400+random()*63071999) into date_pr; 
return date_pr;
END
$$;
 &   DROP FUNCTION public.generate_date();
       public          postgres    false            �            1255    18352    generate_num(integer)    FUNCTION        CREATE FUNCTION public.generate_num(count_char integer) RETURNS text
    LANGUAGE plpgsql
    AS $$
DECLARE
BEGIN
return array_to_string(array(select substr('1234567890', trunc(random()*10)::integer +1, 1)
from generate_series(1,count_char)), '');
END
$$;
 7   DROP FUNCTION public.generate_num(count_char integer);
       public          postgres    false            �            1255    18373    generate_routes(integer)    FUNCTION     3  CREATE FUNCTION public.generate_routes(count_int integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
DECLARE
countr text;
clim text;
durat int;
hotl text;
pric int;
BEGIN
FOR counter in 1..count_int loop
select generate_ru_str(15) into countr;
select generate_ru_str(8) into clim;
select generate_num(6)::integer into durat;
select generate_ru_str(7) into hotl;
select generate_num(6)::integer into pric;
insert into "TravelCompany".routes(id_routes, country, climate, duration, hotel, price)
values (counter, countr, clim, durat, hotl, pric);
end loop;
END
$$;
 9   DROP FUNCTION public.generate_routes(count_int integer);
       public          postgres    false            �            1255    18353    generate_ru_str(integer)    FUNCTION     =  CREATE FUNCTION public.generate_ru_str(count_char integer) RETURNS text
    LANGUAGE plpgsql
    AS $$
DECLARE
BEGIN
return array_to_string(array(select substr('АБВГДЕЁЖЗИЙКЛМНОПРОСТУФХЦЧШЩЪЫЬЭЮЯ', trunc(random()*33)::integer +1, 1)
from generate_series(1,count_char)), '');
END
$$;
 :   DROP FUNCTION public.generate_ru_str(count_char integer);
       public          postgres    false            �            1255    18375    generate_voucher(integer)    FUNCTION       CREATE FUNCTION public.generate_voucher(count_int integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
DECLARE
id_cus int;
depar date;
quant int;
discon int;
id_rout int;
max_id_routs int;
max_id_cust int;
BEGIN
select count(*) into max_id_routs from "TravelCompany".routes;
select count(*) into max_id_cust from "TravelCompany".client;
FOR counter in 1..count_int loop
select floor(random()*max_id_routs+1)::integer into id_rout;
select floor (random()*max_id_cust+1)::integer into id_cus;
select generate_date() into depar;
select generate_num(6)::integer into quant;
select generate_num(2)::integer into discon;
insert into "TravelCompany".voucher(id_voucher, id_costumer, departure, quantity, discount, id_routes)
values (counter, id_cus, depar, quant, discon, id_rout);
end loop;
END
$$;
 :   DROP FUNCTION public.generate_voucher(count_int integer);
       public          postgres    false            �            1255    19029    month_sum()    FUNCTION     K  CREATE FUNCTION public.month_sum() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
DECLARE 
summ int;
BEGIN
select sum(quantity*price) into summ from trips, routes
WHERE trips.id_route = routes.id_route
AND (date_travel<=now() AND date_travel>=now()-interval '1 month');
UPDATE trips set all_sum_column = summ;
return new;
END;
$$;
 "   DROP FUNCTION public.month_sum();
       public          postgres    false            �            1255    18884    search_client(text)    FUNCTION     �   CREATE FUNCTION public.search_client(phone_num text) RETURNS TABLE(id_client integer)
    LANGUAGE plpgsql
    AS $$
DECLARE
BEGIN
RETURN QUERY SELECT clientle.id_client from clientle where phone like ('%'||phone_num||'%');
END;
$$;
 4   DROP FUNCTION public.search_client(phone_num text);
       public          postgres    false            �            1255    18899    search_route(text)    FUNCTION     �   CREATE FUNCTION public.search_route(nameroute text) RETURNS TABLE(id_route integer)
    LANGUAGE plpgsql
    AS $$
DECLARE
BEGIN
RETURN QUERY SELECT routes.id_route from routes where name_route like ('%'||nameroute||'%');
END;
$$;
 3   DROP FUNCTION public.search_route(nameroute text);
       public          postgres    false            �            1259    18637    cities    TABLE     r   CREATE TABLE public.cities (
    id_city integer NOT NULL,
    id_country integer NOT NULL,
    name_city text
);
    DROP TABLE public.cities;
       public         heap    postgres    false            �            1259    18635    cities_id_city_seq    SEQUENCE     �   CREATE SEQUENCE public.cities_id_city_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.cities_id_city_seq;
       public          postgres    false    207            �           0    0    cities_id_city_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.cities_id_city_seq OWNED BY public.cities.id_city;
          public          postgres    false    206            �            1259    18772    clientle    TABLE     �   CREATE TABLE public.clientle (
    id_client integer NOT NULL,
    surname text,
    name_client text,
    middle_name text,
    email text,
    address json,
    phone text,
    CONSTRAINT clientle_email_check CHECK ((email <> ''::text))
);
    DROP TABLE public.clientle;
       public         heap    postgres    false            �            1259    18770    clientle_id_client_seq    SEQUENCE     �   CREATE SEQUENCE public.clientle_id_client_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.clientle_id_client_seq;
       public          postgres    false    213            �           0    0    clientle_id_client_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.clientle_id_client_seq OWNED BY public.clientle.id_client;
          public          postgres    false    212            �            1259    18813 	   countries    TABLE     c   CREATE TABLE public.countries (
    id_country integer NOT NULL,
    name_country text NOT NULL
);
    DROP TABLE public.countries;
       public         heap    postgres    false            �            1259    18811    countries_id_country_seq    SEQUENCE     �   CREATE SEQUENCE public.countries_id_country_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.countries_id_country_seq;
       public          postgres    false    217            �           0    0    countries_id_country_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public.countries_id_country_seq OWNED BY public.countries.id_country;
          public          postgres    false    216            �            1259    18654    hotels    TABLE     �   CREATE TABLE public.hotels (
    id_hotel integer NOT NULL,
    id_city integer NOT NULL,
    name_hotel text NOT NULL,
    id_hotel_category integer DEFAULT 1 NOT NULL,
    id_type_of_food integer DEFAULT 1 NOT NULL
);
    DROP TABLE public.hotels;
       public         heap    postgres    false            �            1259    18827    hotels_categories    TABLE     B  CREATE TABLE public.hotels_categories (
    id_hotel_category integer NOT NULL,
    name_hotel_category text,
    CONSTRAINT chk_name_hotel_category CHECK ((name_hotel_category = ANY (ARRAY['Бюджетный'::text, 'Туристский'::text, 'Средний'::text, 'Первый'::text, 'Высший'::text])))
);
 %   DROP TABLE public.hotels_categories;
       public         heap    postgres    false            �            1259    18825 '   hotels_categories_id_hotel_category_seq    SEQUENCE     �   CREATE SEQUENCE public.hotels_categories_id_hotel_category_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 >   DROP SEQUENCE public.hotels_categories_id_hotel_category_seq;
       public          postgres    false    219            �           0    0 '   hotels_categories_id_hotel_category_seq    SEQUENCE OWNED BY     s   ALTER SEQUENCE public.hotels_categories_id_hotel_category_seq OWNED BY public.hotels_categories.id_hotel_category;
          public          postgres    false    218            �            1259    18652    hotels_id_hotel_seq    SEQUENCE     �   CREATE SEQUENCE public.hotels_id_hotel_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.hotels_id_hotel_seq;
       public          postgres    false    209            �           0    0    hotels_id_hotel_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.hotels_id_hotel_seq OWNED BY public.hotels.id_hotel;
          public          postgres    false    208            �            1259    18591    roles    TABLE     K  CREATE TABLE public.roles (
    id_role integer NOT NULL,
    name_role text DEFAULT 'Клиент'::text NOT NULL,
    CONSTRAINT chk_idroles CHECK ((id_role = ANY (ARRAY[0, 1, 2]))),
    CONSTRAINT chk_roles CHECK ((name_role = ANY (ARRAY['Администратор'::text, 'Менеджер'::text, 'Клиент'::text])))
);
    DROP TABLE public.roles;
       public         heap    postgres    false            �            1259    18589    roles_id_role_seq    SEQUENCE     �   CREATE SEQUENCE public.roles_id_role_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public.roles_id_role_seq;
       public          postgres    false    203            �           0    0    roles_id_role_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.roles_id_role_seq OWNED BY public.roles.id_role;
          public          postgres    false    202            �            1259    18675    routes    TABLE       CREATE TABLE public.routes (
    id_route integer NOT NULL,
    id_hotel integer NOT NULL,
    number_of_nights integer DEFAULT 7,
    price integer,
    name_route text,
    CONSTRAINT routes_number_of_nights_check CHECK (((number_of_nights > 0) AND (number_of_nights < 15)))
);
    DROP TABLE public.routes;
       public         heap    postgres    false            �            1259    18673    routes_id_route_seq    SEQUENCE     �   CREATE SEQUENCE public.routes_id_route_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.routes_id_route_seq;
       public          postgres    false    211            �           0    0    routes_id_route_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.routes_id_route_seq OWNED BY public.routes.id_route;
          public          postgres    false    210            �            1259    18790    trips    TABLE       CREATE TABLE public.trips (
    id_trip integer NOT NULL,
    id_client integer NOT NULL,
    id_route integer NOT NULL,
    date_travel date,
    quantity integer,
    total_sum integer NOT NULL,
    all_sum_column integer,
    CONSTRAINT trips_quantity_check CHECK ((quantity > 0))
);
    DROP TABLE public.trips;
       public         heap    postgres    false            �            1259    18788    trips_id_trip_seq    SEQUENCE     �   CREATE SEQUENCE public.trips_id_trip_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public.trips_id_trip_seq;
       public          postgres    false    215            �           0    0    trips_id_trip_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.trips_id_trip_seq OWNED BY public.trips.id_trip;
          public          postgres    false    214            �            1259    18839    typies_of_food    TABLE     C  CREATE TABLE public.typies_of_food (
    id_type_of_food integer NOT NULL,
    name_type_of_food text,
    CONSTRAINT chk_name_type_of_food CHECK ((name_type_of_food = ANY (ARRAY['Room Only'::text, 'Bed and Breakfast'::text, 'Half Board'::text, 'Full Board'::text, 'All Inclusive'::text, 'Ultra All Inclusive'::text])))
);
 "   DROP TABLE public.typies_of_food;
       public         heap    postgres    false            �            1259    18837 "   typies_of_food_id_type_of_food_seq    SEQUENCE     �   CREATE SEQUENCE public.typies_of_food_id_type_of_food_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public.typies_of_food_id_type_of_food_seq;
       public          postgres    false    221            �           0    0 "   typies_of_food_id_type_of_food_seq    SEQUENCE OWNED BY     i   ALTER SEQUENCE public.typies_of_food_id_type_of_food_seq OWNED BY public.typies_of_food.id_type_of_food;
          public          postgres    false    220            �            1259    18603    users    TABLE     �   CREATE TABLE public.users (
    id_user integer NOT NULL,
    id_role integer NOT NULL,
    login_user text NOT NULL,
    pass_user text NOT NULL
);
    DROP TABLE public.users;
       public         heap    postgres    false            �            1259    18601    users_id_user_seq    SEQUENCE     �   CREATE SEQUENCE public.users_id_user_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public.users_id_user_seq;
       public          postgres    false    205            �           0    0    users_id_user_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.users_id_user_seq OWNED BY public.users.id_user;
          public          postgres    false    204            �
           2604    18640    cities id_city    DEFAULT     p   ALTER TABLE ONLY public.cities ALTER COLUMN id_city SET DEFAULT nextval('public.cities_id_city_seq'::regclass);
 =   ALTER TABLE public.cities ALTER COLUMN id_city DROP DEFAULT;
       public          postgres    false    206    207    207            �
           2604    18775    clientle id_client    DEFAULT     x   ALTER TABLE ONLY public.clientle ALTER COLUMN id_client SET DEFAULT nextval('public.clientle_id_client_seq'::regclass);
 A   ALTER TABLE public.clientle ALTER COLUMN id_client DROP DEFAULT;
       public          postgres    false    212    213    213            �
           2604    18816    countries id_country    DEFAULT     |   ALTER TABLE ONLY public.countries ALTER COLUMN id_country SET DEFAULT nextval('public.countries_id_country_seq'::regclass);
 C   ALTER TABLE public.countries ALTER COLUMN id_country DROP DEFAULT;
       public          postgres    false    216    217    217            �
           2604    18657    hotels id_hotel    DEFAULT     r   ALTER TABLE ONLY public.hotels ALTER COLUMN id_hotel SET DEFAULT nextval('public.hotels_id_hotel_seq'::regclass);
 >   ALTER TABLE public.hotels ALTER COLUMN id_hotel DROP DEFAULT;
       public          postgres    false    209    208    209            �
           2604    18830 #   hotels_categories id_hotel_category    DEFAULT     �   ALTER TABLE ONLY public.hotels_categories ALTER COLUMN id_hotel_category SET DEFAULT nextval('public.hotels_categories_id_hotel_category_seq'::regclass);
 R   ALTER TABLE public.hotels_categories ALTER COLUMN id_hotel_category DROP DEFAULT;
       public          postgres    false    218    219    219            �
           2604    18594    roles id_role    DEFAULT     n   ALTER TABLE ONLY public.roles ALTER COLUMN id_role SET DEFAULT nextval('public.roles_id_role_seq'::regclass);
 <   ALTER TABLE public.roles ALTER COLUMN id_role DROP DEFAULT;
       public          postgres    false    202    203    203            �
           2604    18678    routes id_route    DEFAULT     r   ALTER TABLE ONLY public.routes ALTER COLUMN id_route SET DEFAULT nextval('public.routes_id_route_seq'::regclass);
 >   ALTER TABLE public.routes ALTER COLUMN id_route DROP DEFAULT;
       public          postgres    false    211    210    211            �
           2604    18793    trips id_trip    DEFAULT     n   ALTER TABLE ONLY public.trips ALTER COLUMN id_trip SET DEFAULT nextval('public.trips_id_trip_seq'::regclass);
 <   ALTER TABLE public.trips ALTER COLUMN id_trip DROP DEFAULT;
       public          postgres    false    214    215    215            �
           2604    18842    typies_of_food id_type_of_food    DEFAULT     �   ALTER TABLE ONLY public.typies_of_food ALTER COLUMN id_type_of_food SET DEFAULT nextval('public.typies_of_food_id_type_of_food_seq'::regclass);
 M   ALTER TABLE public.typies_of_food ALTER COLUMN id_type_of_food DROP DEFAULT;
       public          postgres    false    220    221    221            �
           2604    18606    users id_user    DEFAULT     n   ALTER TABLE ONLY public.users ALTER COLUMN id_user SET DEFAULT nextval('public.users_id_user_seq'::regclass);
 <   ALTER TABLE public.users ALTER COLUMN id_user DROP DEFAULT;
       public          postgres    false    205    204    205            �          0    18637    cities 
   TABLE DATA           @   COPY public.cities (id_city, id_country, name_city) FROM stdin;
    public          postgres    false    207   ��       �          0    18772    clientle 
   TABLE DATA           g   COPY public.clientle (id_client, surname, name_client, middle_name, email, address, phone) FROM stdin;
    public          postgres    false    213   ��       �          0    18813 	   countries 
   TABLE DATA           =   COPY public.countries (id_country, name_country) FROM stdin;
    public          postgres    false    217   j�       �          0    18654    hotels 
   TABLE DATA           c   COPY public.hotels (id_hotel, id_city, name_hotel, id_hotel_category, id_type_of_food) FROM stdin;
    public          postgres    false    209   7�       �          0    18827    hotels_categories 
   TABLE DATA           S   COPY public.hotels_categories (id_hotel_category, name_hotel_category) FROM stdin;
    public          postgres    false    219   ��       �          0    18591    roles 
   TABLE DATA           3   COPY public.roles (id_role, name_role) FROM stdin;
    public          postgres    false    203   f�       �          0    18675    routes 
   TABLE DATA           Y   COPY public.routes (id_route, id_hotel, number_of_nights, price, name_route) FROM stdin;
    public          postgres    false    211   ��       �          0    18790    trips 
   TABLE DATA           o   COPY public.trips (id_trip, id_client, id_route, date_travel, quantity, total_sum, all_sum_column) FROM stdin;
    public          postgres    false    215   ƙ       �          0    18839    typies_of_food 
   TABLE DATA           L   COPY public.typies_of_food (id_type_of_food, name_type_of_food) FROM stdin;
    public          postgres    false    221   \�       �          0    18603    users 
   TABLE DATA           H   COPY public.users (id_user, id_role, login_user, pass_user) FROM stdin;
    public          postgres    false    205   ƚ       �           0    0    cities_id_city_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.cities_id_city_seq', 47, true);
          public          postgres    false    206            �           0    0    clientle_id_client_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.clientle_id_client_seq', 13, true);
          public          postgres    false    212            �           0    0    countries_id_country_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public.countries_id_country_seq', 254, true);
          public          postgres    false    216            �           0    0 '   hotels_categories_id_hotel_category_seq    SEQUENCE SET     U   SELECT pg_catalog.setval('public.hotels_categories_id_hotel_category_seq', 5, true);
          public          postgres    false    218            �           0    0    hotels_id_hotel_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.hotels_id_hotel_seq', 15, true);
          public          postgres    false    208            �           0    0    roles_id_role_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.roles_id_role_seq', 1, false);
          public          postgres    false    202            �           0    0    routes_id_route_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.routes_id_route_seq', 35, true);
          public          postgres    false    210            �           0    0    trips_id_trip_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.trips_id_trip_seq', 17, true);
          public          postgres    false    214            �           0    0 "   typies_of_food_id_type_of_food_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public.typies_of_food_id_type_of_food_seq', 6, true);
          public          postgres    false    220            �           0    0    users_id_user_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.users_id_user_seq', 26, true);
          public          postgres    false    204            �
           2606    18645    cities cities_pkey 
   CONSTRAINT     U   ALTER TABLE ONLY public.cities
    ADD CONSTRAINT cities_pkey PRIMARY KEY (id_city);
 <   ALTER TABLE ONLY public.cities DROP CONSTRAINT cities_pkey;
       public            postgres    false    207            �
           2606    18786    clientle clientle_email_key 
   CONSTRAINT     W   ALTER TABLE ONLY public.clientle
    ADD CONSTRAINT clientle_email_key UNIQUE (email);
 E   ALTER TABLE ONLY public.clientle DROP CONSTRAINT clientle_email_key;
       public            postgres    false    213            �
           2606    18888    clientle clientle_email_key1 
   CONSTRAINT     X   ALTER TABLE ONLY public.clientle
    ADD CONSTRAINT clientle_email_key1 UNIQUE (email);
 F   ALTER TABLE ONLY public.clientle DROP CONSTRAINT clientle_email_key1;
       public            postgres    false    213            �
           2606    18886    clientle clientle_phone_key 
   CONSTRAINT     W   ALTER TABLE ONLY public.clientle
    ADD CONSTRAINT clientle_phone_key UNIQUE (phone);
 E   ALTER TABLE ONLY public.clientle DROP CONSTRAINT clientle_phone_key;
       public            postgres    false    213            �
           2606    18782    clientle clientle_pkey 
   CONSTRAINT     [   ALTER TABLE ONLY public.clientle
    ADD CONSTRAINT clientle_pkey PRIMARY KEY (id_client);
 @   ALTER TABLE ONLY public.clientle DROP CONSTRAINT clientle_pkey;
       public            postgres    false    213                        2606    18821    countries countries_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public.countries
    ADD CONSTRAINT countries_pkey PRIMARY KEY (id_country);
 B   ALTER TABLE ONLY public.countries DROP CONSTRAINT countries_pkey;
       public            postgres    false    217                       2606    18835 (   hotels_categories hotels_categories_pkey 
   CONSTRAINT     u   ALTER TABLE ONLY public.hotels_categories
    ADD CONSTRAINT hotels_categories_pkey PRIMARY KEY (id_hotel_category);
 R   ALTER TABLE ONLY public.hotels_categories DROP CONSTRAINT hotels_categories_pkey;
       public            postgres    false    219            �
           2606    18662    hotels hotels_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.hotels
    ADD CONSTRAINT hotels_pkey PRIMARY KEY (id_hotel);
 <   ALTER TABLE ONLY public.hotels DROP CONSTRAINT hotels_pkey;
       public            postgres    false    209            �
           2606    18599    roles roles_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pkey PRIMARY KEY (id_role);
 :   ALTER TABLE ONLY public.roles DROP CONSTRAINT roles_pkey;
       public            postgres    false    203            �
           2606    18685    routes routes_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.routes
    ADD CONSTRAINT routes_pkey PRIMARY KEY (id_route);
 <   ALTER TABLE ONLY public.routes DROP CONSTRAINT routes_pkey;
       public            postgres    false    211            �
           2606    18796    trips trips_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.trips
    ADD CONSTRAINT trips_pkey PRIMARY KEY (id_trip);
 :   ALTER TABLE ONLY public.trips DROP CONSTRAINT trips_pkey;
       public            postgres    false    215                       2606    18847 "   typies_of_food typies_of_food_pkey 
   CONSTRAINT     m   ALTER TABLE ONLY public.typies_of_food
    ADD CONSTRAINT typies_of_food_pkey PRIMARY KEY (id_type_of_food);
 L   ALTER TABLE ONLY public.typies_of_food DROP CONSTRAINT typies_of_food_pkey;
       public            postgres    false    221            �
           2606    18613    users users_login_user_key 
   CONSTRAINT     [   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_login_user_key UNIQUE (login_user);
 D   ALTER TABLE ONLY public.users DROP CONSTRAINT users_login_user_key;
       public            postgres    false    205            �
           2606    18615    users users_pass_user_key 
   CONSTRAINT     Y   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pass_user_key UNIQUE (pass_user);
 C   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pass_user_key;
       public            postgres    false    205            �
           2606    18611    users users_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id_user);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    205            �
           1259    18651 
   idcityname    INDEX     K   CREATE INDEX idcityname ON public.cities USING btree (id_city, name_city);
    DROP INDEX public.idcityname;
       public            postgres    false    207    207            �
           1259    18787    idclientsurname    INDEX     R   CREATE INDEX idclientsurname ON public.clientle USING btree (id_client, surname);
 #   DROP INDEX public.idclientsurname;
       public            postgres    false    213    213                       1259    18822    idcountryname    INDEX     W   CREATE INDEX idcountryname ON public.countries USING btree (id_country, name_country);
 !   DROP INDEX public.idcountryname;
       public            postgres    false    217    217            �
           1259    18668    idhotelname    INDEX     N   CREATE INDEX idhotelname ON public.hotels USING btree (id_hotel, name_hotel);
    DROP INDEX public.idhotelname;
       public            postgres    false    209    209            �
           1259    18600 
   idrolename    INDEX     J   CREATE INDEX idrolename ON public.roles USING btree (id_role, name_role);
    DROP INDEX public.idrolename;
       public            postgres    false    203    203            �
           1259    18686    idroute    INDEX     >   CREATE INDEX idroute ON public.routes USING btree (id_route);
    DROP INDEX public.idroute;
       public            postgres    false    211            �
           1259    18808    idtrip    INDEX     ;   CREATE INDEX idtrip ON public.trips USING btree (id_trip);
    DROP INDEX public.idtrip;
       public            postgres    false    215            �
           1259    18621    iduserlogin    INDEX     L   CREATE INDEX iduserlogin ON public.users USING btree (id_user, login_user);
    DROP INDEX public.iduserlogin;
       public            postgres    false    205    205            �
           1259    18872 	   nameroute    INDEX     B   CREATE INDEX nameroute ON public.routes USING btree (name_route);
    DROP INDEX public.nameroute;
       public            postgres    false    211                       2620    19030    trips on_date_insert    TRIGGER     m   CREATE TRIGGER on_date_insert AFTER INSERT ON public.trips FOR EACH ROW EXECUTE FUNCTION public.month_sum();
 -   DROP TRIGGER on_date_insert ON public.trips;
       public          postgres    false    245    215                       2606    18867    cities fkidc    FK CONSTRAINT     z   ALTER TABLE ONLY public.cities
    ADD CONSTRAINT fkidc FOREIGN KEY (id_country) REFERENCES public.countries(id_country);
 6   ALTER TABLE ONLY public.cities DROP CONSTRAINT fkidc;
       public          postgres    false    2816    217    207                       2606    18862    routes fkidh    FK CONSTRAINT     s   ALTER TABLE ONLY public.routes
    ADD CONSTRAINT fkidh FOREIGN KEY (id_hotel) REFERENCES public.hotels(id_hotel);
 6   ALTER TABLE ONLY public.routes DROP CONSTRAINT fkidh;
       public          postgres    false    2797    209    211            	           2606    18851    hotels fkidhc    FK CONSTRAINT     �   ALTER TABLE ONLY public.hotels
    ADD CONSTRAINT fkidhc FOREIGN KEY (id_hotel_category) REFERENCES public.hotels_categories(id_hotel_category);
 7   ALTER TABLE ONLY public.hotels DROP CONSTRAINT fkidhc;
       public          postgres    false    209    2819    219            
           2606    18856    hotels fkidtf    FK CONSTRAINT     �   ALTER TABLE ONLY public.hotels
    ADD CONSTRAINT fkidtf FOREIGN KEY (id_type_of_food) REFERENCES public.typies_of_food(id_type_of_food);
 7   ALTER TABLE ONLY public.hotels DROP CONSTRAINT fkidtf;
       public          postgres    false    2821    221    209                       2606    18663    hotels hotels_id_city_fkey    FK CONSTRAINT        ALTER TABLE ONLY public.hotels
    ADD CONSTRAINT hotels_id_city_fkey FOREIGN KEY (id_city) REFERENCES public.cities(id_city);
 D   ALTER TABLE ONLY public.hotels DROP CONSTRAINT hotels_id_city_fkey;
       public          postgres    false    2794    209    207                       2606    18797    trips trips_id_client_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.trips
    ADD CONSTRAINT trips_id_client_fkey FOREIGN KEY (id_client) REFERENCES public.clientle(id_client);
 D   ALTER TABLE ONLY public.trips DROP CONSTRAINT trips_id_client_fkey;
       public          postgres    false    213    215    2810                       2606    18894    trips trips_id_route_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.trips
    ADD CONSTRAINT trips_id_route_fkey FOREIGN KEY (id_route) REFERENCES public.routes(id_route) ON DELETE RESTRICT;
 C   ALTER TABLE ONLY public.trips DROP CONSTRAINT trips_id_route_fkey;
       public          postgres    false    215    2802    211                       2606    18616    users users_id_role_fkey    FK CONSTRAINT     |   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_id_role_fkey FOREIGN KEY (id_role) REFERENCES public.roles(id_role);
 B   ALTER TABLE ONLY public.users DROP CONSTRAINT users_id_role_fkey;
       public          postgres    false    2785    203    205            �   �  x�mSKn�P\�wq��$����HQ����N��C�R��Աc�
�2��캰�8$�ÏC2]h�{m���Jm$f1ӹv ɳ<�"�VK�����N�d@�ϝM���{�ṱ���F��©�i��@L�FB��M�n�A�NB����
���7��t�
�!�sn5�wz@�*}%��+}E��'���a�(Im��?ªA_�ң!�;X�Ovh��qbC���%L<yK���(ћ�����jĐPx�\(��M�!��MO� k}lT��5m���,�n돣-Z�u+q@���}�8���Y�X�θ(;�x�aX3Z^��vG���b鈺O�e�y�v��_)mB����<�r�uާ�B�q����M%�\���^�������^�A��N�M�6VJ^���w�|@�y%O�:Ɇ�Vyx�}���<E�����Τ�����+f�ǌԷ]H���g9 ����>���DD> ����      �   �  x���KK�@ ����t��<<��xi�<Zj"M�"XE�

��Ƀ�R��G�f�����ED� 3��|�e.ac��&�A)3yD�i#�Rۮo7ۯ��Ȏ洓mmM�S9��r��0�Hk�+Z��\7ɖ����^�j�l1��b�,+��n#{QT�]b�U���ƫ6���i^:�A)��6ݤ���W�����=�!��W�:&0(p��	n0f��r#��X,y#T��=L�Y�2n�"T������r�SX|�`U��`��ΨE�
�{#p���;�u��7�n�q���y�9ܗ��m�̆֓�Q��0Ձ1�$q��M6��+O�Ҍ������βz?��/�.��C0.e�����7}�8����<��I|&�緼���������N�*mu]�c_�z]�e3A�+��w�^��      �   �	  x��X[v���V�s�@ {�b,ɞщ=���9��a=�I����H	|j��r�n����ۅFUu=nw���֌����}��yS��"�	��	�w��6����(���=�$����\rK�<0���Q��B+�͌2�>~Wͤ�\a���0*)�l�!3o?`�* +�4����c|���D�h���f�k�^�{3���)C�0�o&^rI45tAT
'��u�yԾ�[f�"�؅��/dDM#�z���_.L��Cq�1i�����	[��QR��^F.&2�4��K&�+��W�����HjȒF.ӈ��)�r�ѻ�RLVCF�́��)��3o�ﵖyՕ&y ّ �&*���Y�a�yU��2�m-'V�P���/������Y��o����(Mvד��
OFT\m� uznZr������H��(�߬�4�S�>Q�b���u�R ��OFi!Da73����/-�ۨm��l��7$�2����J�,�{ٺ���d1����ʹ�\CvAG�=FM �dPG����;,�\�mD�(�h�77+l���t-m����#�D�a�4�=ʽ�{CY�'�ֲ�S���qQ��K�Q��Y��esZ���@5�ҵ��н05��+n����E�f��4A鸔�P�� s}sl%.�8�@�Dc�hc�P�S�����q4Q[FrCX	gҍ��n�ύ�R�'(�����9p�%}0(lL/j�%$�ܪ�A��u��oF��CQ�Ĩ�
��g'
g�'�oi]�ȩ�`���^`����<�y�~��GE�Ҟ��h�<5Q��ڷ���ufQQ��eT�����2!���9Þ�+�)��u�,�뿴W�=O,]��S)3�ʁ����}���S�H����T�&�P
��Fe������	QZ%�X�G��U)G�0�dz����X���'��j`�F�g�e�ڻ��*M�����S�iߣ�Co��6���(��KdI�?�7c���j�LЖХ��#�n�bӒ��e74�`�)�o�B|�z[��$3��_��S�CQ ���uwLH0N�(�~2ߩ�-�#�N�"�=m?"��>w*C����gX|�	�A�t�����v]}۲�!�8St�H�ʠ�����JZ�4��J1��6��IB�a %2?@�`gqo]����lP��<�
y.��ە>�'�!7�Q+'�&�5�Q�1�NuHR��bZ<�$$�3p.h�45h)�@�4�qO[-����Ċ4c�m���������gA¶����Ű�p�"3��9��Q�����'�Π� _�6M?�`:������.�]c�?7g�V�I��q`0�@+����Ƶ)�IVl͟h�b,�X�Gb��_�����=��V\~�6w�n�Q�w�M*��
)�Y'Tz�e�,	���̉Zٓ��p���gRg Zĳg��rd(*�sB�3�B�Vq�p#�ؚ��σ6a?���-�+��'i���<	���ۖ:Vh��J���������>�D_Ur�SUB����7�:��ճ����iխp��22�i�2��Q������#+�Z��2���Ɏ�"d] ������n�X�:0Hw�.T9g������f^H��.7p.z��G]���l&�"�f�׍�.gMȯ.B�Y���`]X�ƹ0�`�4=�A1 ��P�I�S�"44F�&���C�)�|�[|�N]j��`������$S�>���R��yB:ue1eE���s�V�V��h�/LB���=�t�D��J�fZ��~Jv%�ف����"��`d<?ԙ�8_˶歄5�����+�#;Q�z�'���oyu��Z9�+ֳg�Yx�,���Z�	�Xv��T�T���C$A�ޕ��sH�*b�t�yk�%{.�Ժqp����W�ȡ�bJ���T���[fVrNV%oX[�,7��ޥ�嫗:�w��Ҁ��Q�8���F-7T��G�����G^yeWC�mI5��̓�#����bX�I�W`�_���ɺ�8��k;�XN*�sġƑn^k�qM�)絬����3��v�H?��b���B�ˑ�^���$��ޠZvZ��ȝJ��(t(��Z$7@�]4�-H�#[�J�I�u$���]�X:TI���D��N��Έ�󛶒����U�P �}ө'TUG*z�ܶ���Qo�n=���A��[�8r�)3������x(B����93��<u�J`S��i��1��W�.�-܆�:2�]i��_�Ӧ�p����$Pt����!/���3�}����[��W)�j������W����x��h�[��I�9��k�XR������暒Zp�8I�wn+ ;���p�w���9pij�Q���.�x�Ȑ=��L�y��;��[����(�]�ޚ�}�r�зv2���d���!����q�i�U[s�Y�� �e;Ap�qd���E�#�馎t:,ک���?TO���������d�?`Q0��������r      �   �   x�=���0�wU���$���H|!�����uG����>��z�v�zD�i��EOɩ��g�#�A��B�V�l��F��3����RJ��yŌ;W�b�.�>x��J�Rp���-�b�3ͩ��8MOM~��W�ir�w��v�Ll��i����%��+Z�U�΀��      �   [   x���	�0���n1��n,&�! h�%�J��LG.��3_-X8����6��#==>$˭`�x�;��	6cga�`e42�u�T�H�8�      �   I   x�ʻ�0�:�0L�Ԉ!(p���o���n,l\<t^�V�*��Oզ�Ad�\�4v�f��(�      �   �   x�uPAN�@<ۯ��כ����>�"!=TpB�_���BK���G���	be���c+)�!�/�rc{�O�/v��Z֜)SKu;�����}@���ꮬ���Ͼܕ+P'B͚Ɠ!~�F���sE�����@�A��Gp:��M�C��&^��o���
�D������2�*���/�R�0���t|��ml���'6fp`:�ue�Ei)��4d@��g?)�|�Yƍ�_���3�3�F      �   �   x�]���0C�x�$N�K���Ц���	�[B��t(B�p �,�fR��M����N�'�+X�/�"`(`,��	��$dâ��� �4ȣ��fu��Bxe�xdJ�����t��;�IB<M����j�} �t69      �   Z   x�3����U��˩�2�tJMQH�KQp*JM�NK,.�2��H�ISp�O,J�2�t+�ɁrL9�lϼ���̲T.3�М��DT�=... )��      �   �   x�E�=�0Fg� !��i:V�p�Pڤ�?��	��#��
<Y���d�%��	@B*֨�`c�u�I�L�B���f�4?�")�ɒ@0�w(��
�'�Ugo�3>�+�'�2,P��"��d�L]�(t�����][��V�s?�L:����q�L�J�ĸ] ��6W     