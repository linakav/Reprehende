<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Reprehende.register" %>
<%@ Register TagPrefix="uc" TagName="Breadcrumb" Src="/controls/breadcrumb.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_wrapper">
        <uc:Breadcrumb id="BreadcrumbControl" runat="server"/>
        <div class="main_content_wrapper clearfix">
            <div class="register_login_wrapper">
                <h1 class="title main_title">O ΛΟΓΑΡΙΑΣΜΟΣ ΜΟΥ</h1>
                <div class="back_to_eshop_wrapper">
                    <a class="back_to_eshop" href="/">Πίσω στο eshop</a>
                </div>
                <div class="login_forcot_password section">
                    <div class="login_wrapper">
                        <h2 class="title">ΕΙΣΟΔΟΣ ΧΡΗΣΤΗ</h2>
                        <div class="form_description_wrapper">
                            <div class="loading"></div>
                            <div class="message_wrapper">
                                <span class="description">Εάν έχετε ήδη εγγραφεί, μπορείτε να εισέλθετε στο λογαριασμό σας παρακάτω.</span>
                                <span class="message generic_error">Παρουσιάστηκε κάποιο σφάλμα. Παρακαλώ προσπαθήστε ξανά αργότερα.</span>
                                </div>
                            <form action="#" method="post" class="form">
                                <div class="row_wrapper">
                                    <label class="label">Email</label>
                                    <div class="input_wrapper email_wrapper">
                                        <input type="text" name="email" class="input email" />
                                        <span class="message empty_error" >Συμπληρώστε το email σας</span>
                                    </div>
                                </div>
                                <div class="row_wrapper">
                                    <label class="label">Κωδικός</label>
                                    <div class="input_wrapper password_wrapper">
                                        <input type="password" name="password" class="input password" />
                                        <span class="message empty_error" >Συμπληρώστε τον κωδικό σας</span>
                                    </div>
                                </div>
                                <div class="forgot_password">
                                    <span class="forgot_password_text">Ξεχάσατε τον κωδικό πρόσβασης;</span>
                                    <span class="forgot_password_link open">Πατήστε εδώ</span>
                                </div>
                                <div class="row_wrapper lastrow_wrapper">
                                    <button class="submit_btn" >ΣΥΝΔΕΣΗ</button>
                                </div>
                            </form>
                        </div>
                    </div>
                    <div class="forgot_password_wrapper closed">
                        <span class="forgot_password_link close">Κλείσιμο</span>
                        <h2 class="title">ΑΝΑΚΤΗΣΗ ΚΩΔΙΚΟΥ</h2>
                        <div class="form_description_wrapper">
                            <div class="loading"></div>
                            <span class="description">Εισάγετε το email σας και πατήστε "ΑΠΟΣΤΟΛΗ" για να σας αποσταλεί ένα link αλλαγής κωδικού.</span>
                            <form action="#" method="post" class="form">
                                <div class="row_wrapper">
                                    <label class="label">Email</label>
                                    <div class="input_wrapper email_wrapper">
                                        <input type="text" name="email" class="input email" />
                                        <span class="message empty_error" >Συμπληρώστε το email σας</span>
                                    </div>
                                </div>
                                <div class="row_wrapper lastrow_wrapper">
                                    <button class="submit_btn" >ΑΠΟΣΤΟΛΗ</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
                <div class="register section">
                    <h2 class="title">ΕΓΓΡΑΦΗ ΝΕΟΥ ΜΕΛΟΥΣ</h2>
                    <div class="form_description_wrapper">
                        <div class="loading"></div>
                        <div class="message_wrapper">
                            <span class="description">Δεν έχετε εγγραφεί; Δημιουργήστε το δικό σας λογαριασμό εδώ.</span>
                            <span class="message generic_error">Παρουσιάστηκε κάποιο σφάλμα. Παρακαλώ προσπαθήστε ξανά αργότερα.</span>
                            <span class="message account_exists">Υπάρχει ήδη ένας λογαριασμός για αυτό το email.</span>
                        </div>
                        <form action="#" method="post" class="form">
                        <div class="row_wrapper">
                            <label class="label">Όνομα</label>
                            <div class="input_wrapper required">
                                <input type="text" name="firstName" class="input first_name" />
                                <span class="message empty_error" >Συμπληρώστε το όνομά σας</span>
                            </div>
                        </div>
                        <div class="row_wrapper">
                            <label class="label">Επώνυμο</label>
                            <div class="input_wrapper required">
                                <input type="text" name="lastName" class="input last_name" />
                                <span class="message empty_error" >Συμπληρώστε το επώνυμό σας</span>
                            </div>
                        </div>
                        <div class="row_wrapper">
                            <label class="label">Email</label>
                            <div class="input_wrapper required email_wrapper">
                                <input type="text" name="email" class="input email" />
                                <span class="message empty_error" >Συμπληρώστε το email σας</span>
                                <span class="message invalid_error">Συμπληρώστε ένα έγγυρο email</span>
                            </div>
                        </div>
                        <div class="row_wrapper">
                            <label class="label">Κωδικός</label>
                            <div class="input_wrapper required password_wrapper">
                                <input type="password" name="password" class="input password" />
                                <span class="message empty_error" >Συμπληρώστε τον κωδικό σας</span>
                            </div>
                        </div>
                        <div class="row_wrapper">
                            <label class="label">Επιβεβαίωση</label>
                            <div class="input_wrapper required password_wrapper">
                                <input type="password" name="passwordConfirmation" class="input password_confirm" />
                                <span class="message empty_error" >Συμπληρώστε ξανά τον κωδικό σας</span>
                                <span class="message not_same_error" >Οι κωδικοί που εισάγατε δεν είναι ίδιοι.</span>
                            </div>
                        </div>
                        <div class="newsletter_row_wrapper row_wrapper">
            	            <input id="nslckb" type="checkbox" name="newsletter" class="newsletter_ckb"/>
                            <label class="label newsletter" for="nslckb">Θα ήθελα να λαμβάνω το newsletter</label>
                        </div>
                        <div class="row_wrapper lastrow_wrapper">
                            <span class="footnote">Υποχρεωτικά πεδία <span class="footnote_star">*</span></span>
                            <button class="submit_btn" >ΕΓΓΡΑΦΗ</button>
                        </div>
                    </form>
                    </div>
                    <div class="success_wrapper">
                        <span class="success_message">Η εγγραφή ολοκληρώθηκε με επιτυχία.</span>
                    </div>
                </div>
            </div>
        </div>  
    </div><!-- End content_wrapper -->
</asp:Content>
