cookie_auth = (document.cookie.match(/^(?:.*;)?\s*Authorization\s*=\s*([^;]+)(?:.*)?$/) || [, null])[1]
if (cookie_auth == null) {
    fetch("/_configuration/DotnetAngular").then(
        (config) => {
            var mgr = new Oidc.UserManager(config);
            mgr.signinRedirect();
            mgr.getUser().then(function (user) {
                if (user) {
                    console.log("User logged in", user.profile);
                }
                else {
                    console.log("User not logged in");
                }
                document.cookie = `Authorization=Bearer ${user.access_token}`
            });

        }
    )

}
else {
    $.ajaxSetup({
        headers: {
            Authorization:
                cookie_auth
        }
    });
}
