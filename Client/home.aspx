﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="MP2_IT114L.Client.home" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" href="../images/logo/Jukeboxd-favicon.png" type="image/x-icon" />
    <title>Jukeboxd • We sell everything vinyl.</title>

    <link rel="preload" href="../fonts/clash-display/WEB/fonts/ClashDisplay-Variable.woff2" as="font" type="font/woff2" crossorigin="crossorigin" />

    <link rel="stylesheet" href="../styles/general.css" />
    <link rel="stylesheet" href="../styles/customer.css" />
    <link href="https://cdn.jsdelivr.net/npm/remixicon@4.1.0/fonts/remixicon.css" rel="stylesheet" />
</head>
<body class="">
    <form runat="server">
        <nav class="nav-bar">
            <a href="home.aspx" class="site-logo" id="logo">
                <img src="../images/logo/Jukeboxd-full.svg" alt="Jukeboxd Logo" />
            </a>

            <asp:Panel runat="server" CssClass="search-bar" ID="homeSearchBar">
                <asp:TextBox runat="server" Placeholder="Search for vinyl records" />
                <i class="ri-search-line"></i>
            </asp:Panel>

            <div class="customer-links">
                <a href="./Profile.aspx" class="btn btn-primary">Profile</a>
                <a href="./Checkout.aspx" class="btn btn-primary"><i class="ri-shopping-cart-2-fill"></i><span>0</span></a>
            </div>
        </nav>

        <nav class="nav-bar-squished">
            <div class="nav-squished-container-1">
                <a href="./Home.aspx" class="site-logo" id="logo2">
                    <img src="../images/logo/Jukeboxd-full.svg" alt="Jukeboxd Logo" />
                </a>

                <div class="customer-links"><a href="./Checkout.aspx" class="btn btn-primary"><i class="ri-shopping-cart-2-fill"></i><span>0</span></a></div>
            </div>

            <div class="nav-squished-container-2">
                <asp:Panel runat="server" CssClass="search-bar" ID="searchBarSquished">
                    <asp:TextBox runat="server" Placeholder="Search for vinyl records" />
                    <i class="ri-search-line"></i>
                </asp:Panel>
                <div class="customer-links">
                    <a href="./Profile.aspx" class="btn btn-primary">Profile</a>
                </div>
            </div>
        </nav>
        <main id="main1" runat="server">
            <section class="banner">
                <img src="../images/logo/Jukeboxd-banner.jpeg" />
                <h1>The best <span>vinyl</span> out there.</h1>
            </section>

            <div class="marquee">
                <div class="marquee-content scroll">
                    <div>
                        <img src="../images/logo/Warner-logo.svg" />
                    </div>
                    <div>
                        <img src="../images/logo/Sony-logo.svg" />
                    </div>
                    <div>
                        <img src="../images/logo/Atlantic-logo.svg" />
                    </div>
                    <div>
                        <img src="../images/logo/Jukeboxd-text-black.svg" />
                    </div>
                </div>
                <div class="marquee-content scroll">
                    <div>
                        <img src="../images/logo/Warner-logo.svg" />
                    </div>
                    <div>
                        <img src="../images/logo/Sony-logo.svg" />
                    </div>
                    <div>
                        <img src="../images/logo/Atlantic-logo.svg" />
                    </div>
                    <div>
                        <img src="../images/logo/Jukeboxd-text-black.svg" />
                    </div>
                </div>
            </div>

            <section class="records">
                <header>
                    <h2>The collection.</h2>
                    <p>New arrivals and restocks</p>
                </header>

                <div runat="server" id="recordsgrid" class="records-grid">
                </div>
            </section>

            <section class="about">
                <header>
                    <h2>About</h2>
                    <p>This website is made by Orbit <i class="ri-heart-fill"></i></p>
                </header>
                <div class="about-container">
                    <h1 class="text">ALCANTARA CARL<span><a href="https://github.com/cfd-alcantara" target="_blank">BACK-END</a></span></h1>
                    <h1 class="text">GERONA JULIAN<span><a href="https://github.com/jp-gerona" target="_blank">FRONT-END</a></span></h1>
                    <h1 class="text">REA JAN<span><a href="https://github.com/SuperficialFlow/" target="_blank">BACK-END</a></span></h1>
                    <h1 class="text">SANTOS JR<span><a href="https://github.com/JannersLSR" target="_blank">BACK-END</a></span></h1>
                    <h1 class="text">TIONGCO LUIS<span><a href="https://github.com/LuisTiongco" target="_blank">BACK-END</a></span></h1>
                </div>
            </section>

            <footer>
                <p>Copyright &copy; 2024 Orbit.</p>
                <button class="btn btn-accent"
                    type="button"
                    aria-label="Change to light theme"
                    id="themeButton">
                    <i class="ri-sun-fill"></i>
                </button>
            </footer>
        </main>
    </form>
    <script src="../scripts/theme.js"></script>
</body>
</html>
