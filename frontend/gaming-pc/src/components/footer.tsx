import type React from "react";

const Footer: React.FC = () => {
  return (
    <footer className="bg-black text-white py-8">
      <div className="container mx-auto px-4">
        <div className="grid md:grid-cols-4 gap-8">
          <div>
            <div className="flex items-center space-x-2 mb-4">
              <div className="w-8 h-8 bg-amber-600 rounded-lg flex items-center justify-center">
                <span className="text-white font-bold">Z</span>
              </div>
              <span className="text-lg font-bold">ZIENCLUB</span>
            </div>
            <p className="text-gray-400 text-sm">
              Играй и побеждай.
            </p>
          </div>

          <div>
            <h4 className="font-semibold mb-4">Соц. сети</h4>
            <ul className="space-y-2 text-sm text-gray-400">
              <li>
                <a
                  href="https://github.com/Daniil-sas"
                  className="hover:text-amber-400 transition-colors"
                  target="_blank"
                  rel="noreferrer"
                >
                  GitHub
                </a>
              </li>
              <li>
                <a
                  href="https://x.com/Ziennik"
                  className="hover:text-amber-400 transition-colors"
                  target="_blank"
                  rel="noreferrer"
                >
                  Twitter
                </a>
              </li>
              <li>
                <a
                  href="https://vk.com/mrazeslav_krivinojka"
                  className="hover:text-amber-400 transition-colors"
                  target="_blank"
                  rel="noreferrer"
                >
                  VK
                </a>
              </li>
            </ul>
          </div>
        </div>

        <div className="border-t border-gray-800 mt-8 pt-8 text-center text-sm text-gray-400">
          <p>
            &copy; {new Date().getFullYear()} ZIENCLUB. All rights reserved.
          </p>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
