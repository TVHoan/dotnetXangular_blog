import { Component } from '@angular/core';
import { faTwitter,  faFacebookF, faInstagramSquare,faLinkedin } from '@fortawesome/free-brands-svg-icons';
@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent {
  faTwitter = faTwitter;
  faFacebookF = faFacebookF;
  faInstagramSquare = faInstagramSquare;
  faLinkedin = faLinkedin;
}
