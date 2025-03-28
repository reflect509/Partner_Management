PGDMP  3    #    
            }         	   demo_exam    16.1    16.1 +               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    105042 	   demo_exam    DATABASE     }   CREATE DATABASE demo_exam WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE demo_exam;
                postgres    false            �            1259    105096    partner_products    TABLE     �   CREATE TABLE public.partner_products (
    product_id integer NOT NULL,
    partner_id integer NOT NULL,
    amount integer NOT NULL,
    sell_date date NOT NULL,
    CONSTRAINT partner_products_amount_check CHECK ((amount > 0))
);
 $   DROP TABLE public.partner_products;
       public         heap    postgres    false            �            1259    105071    partner_types    TABLE     �   CREATE TABLE public.partner_types (
    partner_type_id integer NOT NULL,
    partner_type_name character varying(255) NOT NULL
);
 !   DROP TABLE public.partner_types;
       public         heap    postgres    false            �            1259    105070 !   partner_types_partner_type_id_seq    SEQUENCE     �   CREATE SEQUENCE public.partner_types_partner_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 8   DROP SEQUENCE public.partner_types_partner_type_id_seq;
       public          postgres    false    220                       0    0 !   partner_types_partner_type_id_seq    SEQUENCE OWNED BY     g   ALTER SEQUENCE public.partner_types_partner_type_id_seq OWNED BY public.partner_types.partner_type_id;
          public          postgres    false    219            �            1259    105080    partners    TABLE     �  CREATE TABLE public.partners (
    partner_id integer NOT NULL,
    partner_name character varying(255) NOT NULL,
    partner_type integer NOT NULL,
    ceo_name character varying(255) NOT NULL,
    partner_email character varying(50) NOT NULL,
    partner_phone character varying(30) NOT NULL,
    partner_address character varying(255) NOT NULL,
    tin character varying(20) NOT NULL,
    rating numeric(2,0),
    CONSTRAINT partners_rating_check CHECK ((rating > (0)::numeric))
);
    DROP TABLE public.partners;
       public         heap    postgres    false            �            1259    105079    partners_partner_id_seq    SEQUENCE     �   CREATE SEQUENCE public.partners_partner_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.partners_partner_id_seq;
       public          postgres    false    222                        0    0    partners_partner_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.partners_partner_id_seq OWNED BY public.partners.partner_id;
          public          postgres    false    221            �            1259    105044    product_types    TABLE       CREATE TABLE public.product_types (
    product_type_id integer NOT NULL,
    product_type_name character varying(255) NOT NULL,
    type_coefficient numeric(10,2) NOT NULL,
    CONSTRAINT product_types_type_coefficient_check CHECK ((type_coefficient > (0)::numeric))
);
 !   DROP TABLE public.product_types;
       public         heap    postgres    false            �            1259    105043 !   product_types_product_type_id_seq    SEQUENCE     �   CREATE SEQUENCE public.product_types_product_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 8   DROP SEQUENCE public.product_types_product_type_id_seq;
       public          postgres    false    216            !           0    0 !   product_types_product_type_id_seq    SEQUENCE OWNED BY     g   ALTER SEQUENCE public.product_types_product_type_id_seq OWNED BY public.product_types.product_type_id;
          public          postgres    false    215            �            1259    105054    products    TABLE     0  CREATE TABLE public.products (
    product_id integer NOT NULL,
    product_name character varying(255) NOT NULL,
    articul character varying(255) NOT NULL,
    min_cost numeric NOT NULL,
    product_type_id integer NOT NULL,
    CONSTRAINT products_min_cost_check CHECK ((min_cost > (0)::numeric))
);
    DROP TABLE public.products;
       public         heap    postgres    false            �            1259    105053    products_product_id_seq    SEQUENCE     �   CREATE SEQUENCE public.products_product_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.products_product_id_seq;
       public          postgres    false    218            "           0    0    products_product_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.products_product_id_seq OWNED BY public.products.product_id;
          public          postgres    false    217            e           2604    105074    partner_types partner_type_id    DEFAULT     �   ALTER TABLE ONLY public.partner_types ALTER COLUMN partner_type_id SET DEFAULT nextval('public.partner_types_partner_type_id_seq'::regclass);
 L   ALTER TABLE public.partner_types ALTER COLUMN partner_type_id DROP DEFAULT;
       public          postgres    false    219    220    220            f           2604    105083    partners partner_id    DEFAULT     z   ALTER TABLE ONLY public.partners ALTER COLUMN partner_id SET DEFAULT nextval('public.partners_partner_id_seq'::regclass);
 B   ALTER TABLE public.partners ALTER COLUMN partner_id DROP DEFAULT;
       public          postgres    false    221    222    222            c           2604    105047    product_types product_type_id    DEFAULT     �   ALTER TABLE ONLY public.product_types ALTER COLUMN product_type_id SET DEFAULT nextval('public.product_types_product_type_id_seq'::regclass);
 L   ALTER TABLE public.product_types ALTER COLUMN product_type_id DROP DEFAULT;
       public          postgres    false    215    216    216            d           2604    105057    products product_id    DEFAULT     z   ALTER TABLE ONLY public.products ALTER COLUMN product_id SET DEFAULT nextval('public.products_product_id_seq'::regclass);
 B   ALTER TABLE public.products ALTER COLUMN product_id DROP DEFAULT;
       public          postgres    false    217    218    218                      0    105096    partner_products 
   TABLE DATA           U   COPY public.partner_products (product_id, partner_id, amount, sell_date) FROM stdin;
    public          postgres    false    223   37                 0    105071    partner_types 
   TABLE DATA           K   COPY public.partner_types (partner_type_id, partner_type_name) FROM stdin;
    public          postgres    false    220   �7                 0    105080    partners 
   TABLE DATA           �   COPY public.partners (partner_id, partner_name, partner_type, ceo_name, partner_email, partner_phone, partner_address, tin, rating) FROM stdin;
    public          postgres    false    222   8                 0    105044    product_types 
   TABLE DATA           ]   COPY public.product_types (product_type_id, product_type_name, type_coefficient) FROM stdin;
    public          postgres    false    216   ~:                 0    105054    products 
   TABLE DATA           `   COPY public.products (product_id, product_name, articul, min_cost, product_type_id) FROM stdin;
    public          postgres    false    218   ;       #           0    0 !   partner_types_partner_type_id_seq    SEQUENCE SET     O   SELECT pg_catalog.setval('public.partner_types_partner_type_id_seq', 4, true);
          public          postgres    false    219            $           0    0    partners_partner_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.partners_partner_id_seq', 5, true);
          public          postgres    false    221            %           0    0 !   product_types_product_type_id_seq    SEQUENCE SET     O   SELECT pg_catalog.setval('public.product_types_product_type_id_seq', 4, true);
          public          postgres    false    215            &           0    0    products_product_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.products_product_id_seq', 5, true);
          public          postgres    false    217            |           2606    105111 &   partner_products partner_products_pkey 
   CONSTRAINT     x   ALTER TABLE ONLY public.partner_products
    ADD CONSTRAINT partner_products_pkey PRIMARY KEY (product_id, partner_id);
 P   ALTER TABLE ONLY public.partner_products DROP CONSTRAINT partner_products_pkey;
       public            postgres    false    223    223            t           2606    105078 1   partner_types partner_types_partner_type_name_key 
   CONSTRAINT     y   ALTER TABLE ONLY public.partner_types
    ADD CONSTRAINT partner_types_partner_type_name_key UNIQUE (partner_type_name);
 [   ALTER TABLE ONLY public.partner_types DROP CONSTRAINT partner_types_partner_type_name_key;
       public            postgres    false    220            v           2606    105076     partner_types partner_types_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public.partner_types
    ADD CONSTRAINT partner_types_pkey PRIMARY KEY (partner_type_id);
 J   ALTER TABLE ONLY public.partner_types DROP CONSTRAINT partner_types_pkey;
       public            postgres    false    220            x           2606    105088    partners partners_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.partners
    ADD CONSTRAINT partners_pkey PRIMARY KEY (partner_id);
 @   ALTER TABLE ONLY public.partners DROP CONSTRAINT partners_pkey;
       public            postgres    false    222            z           2606    105090    partners partners_tin_key 
   CONSTRAINT     S   ALTER TABLE ONLY public.partners
    ADD CONSTRAINT partners_tin_key UNIQUE (tin);
 C   ALTER TABLE ONLY public.partners DROP CONSTRAINT partners_tin_key;
       public            postgres    false    222            l           2606    105050     product_types product_types_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public.product_types
    ADD CONSTRAINT product_types_pkey PRIMARY KEY (product_type_id);
 J   ALTER TABLE ONLY public.product_types DROP CONSTRAINT product_types_pkey;
       public            postgres    false    216            n           2606    105052 1   product_types product_types_product_type_name_key 
   CONSTRAINT     y   ALTER TABLE ONLY public.product_types
    ADD CONSTRAINT product_types_product_type_name_key UNIQUE (product_type_name);
 [   ALTER TABLE ONLY public.product_types DROP CONSTRAINT product_types_product_type_name_key;
       public            postgres    false    216            p           2606    105064    products products_articul_key 
   CONSTRAINT     [   ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_articul_key UNIQUE (articul);
 G   ALTER TABLE ONLY public.products DROP CONSTRAINT products_articul_key;
       public            postgres    false    218            r           2606    105062    products products_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (product_id);
 @   ALTER TABLE ONLY public.products DROP CONSTRAINT products_pkey;
       public            postgres    false    218                       2606    105105 1   partner_products partner_products_partner_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.partner_products
    ADD CONSTRAINT partner_products_partner_id_fkey FOREIGN KEY (partner_id) REFERENCES public.partners(partner_id);
 [   ALTER TABLE ONLY public.partner_products DROP CONSTRAINT partner_products_partner_id_fkey;
       public          postgres    false    223    4728    222            �           2606    105100 1   partner_products partner_products_product_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.partner_products
    ADD CONSTRAINT partner_products_product_id_fkey FOREIGN KEY (product_id) REFERENCES public.products(product_id);
 [   ALTER TABLE ONLY public.partner_products DROP CONSTRAINT partner_products_product_id_fkey;
       public          postgres    false    4722    223    218            ~           2606    105091 #   partners partners_partner_type_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.partners
    ADD CONSTRAINT partners_partner_type_fkey FOREIGN KEY (partner_type) REFERENCES public.partner_types(partner_type_id);
 M   ALTER TABLE ONLY public.partners DROP CONSTRAINT partners_partner_type_fkey;
       public          postgres    false    4726    222    220            }           2606    105065 &   products products_product_type_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_product_type_id_fkey FOREIGN KEY (product_type_id) REFERENCES public.product_types(product_type_id);
 P   ALTER TABLE ONLY public.products DROP CONSTRAINT products_product_type_id_fkey;
       public          postgres    false    216    218    4716               �   x�U��1�N/f,;�p��(!�wG��0����(�j5a��x�.X�_��qx�����s&#��t���2�����X��]x�F�f�r�M7���wh�K1ɩ.ew[6]Aڴ^��q�$�������weď�~GC�Gk�
*6�         (   x�3�0��8/�A.c���"& #F��� ���         [  x��SInA]�� �5A���d�Qza� �k���0�)R���Q�!f�
�n���1v��$�������RAOTH���ҞV~LK���P�>��;lϸ憶8��Q�\���kvT��������^z���N�6߷j��&F*m�u��u�#U%}A�ߴ�3t�P�%�<��#К�lN�P���s*��_ж&�+n��_W�rBcY�T#��t��!�.�X�D���A�L���
h+Z��g��R��n6�u�fT$q#�puو��[��?���ҽ��LQ;;h_0���Q�3�o��0Xq�B(4�X��m���G����N�'X�m�R�p*�@���~��ɳ����Xi���hEB�q�X/<G�����)z��´����	������� �8h��BN�ph,ix�� W����Xj�h~
����Z�i�� PVqb��t����i-��:o���Z�Z$W	eMRg�߀4*�$��h��e���+(�WU���]C����b��W0n�r�������!O�m,����.?�f���"<,�a��L�m������2=Xy�i�q�d{�� VP�/OSk���(e����V�T�lr��         v   x�e���0�wUP�	c���y�� т�Bര�QV��u����
N�P|��b�A�2�>��~ͽ���@�l!kl,&��˿�,&M��4<�5���'�q��J���h���Q�         '  x�u�MN�0�דS�D��}�*�a�Ă�����$�
���DHT��ɼ��e������cZ��I���ԡ�ޠ�<���y@���L#��X�b��6F�4�w�ko�{]I�R�/0}�8��`�閷��!� ���kֲ1Tl�ja{��䴖u`k�WD�/����4Cz�=��x�!e@�`']����Y���ƅPkMMe.$�cK��~G��]��܂4�r��}��i�lq58�	?�-XQd�<wZ�3�svĳ8�z�h��G�/~�+e�&k��m S��UU� �y(�     